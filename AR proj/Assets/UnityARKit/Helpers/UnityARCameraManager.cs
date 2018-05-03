using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public enum TrackingType : byte {
		ARKit = 0,
		TrackerRelay = 1,
		HeadsetRelay = 2,
		TrackerCalibration = 3,
		HeadsetCalibration = 4
	}
public class UnityARCameraManager : MonoBehaviour {

    public Camera m_camera;
    private UnityARSessionNativeInterface m_session;

	private Material savedClearMaterial;

	[Header("AR Config Options")]

	public UnityARAlignment startAlignment = UnityARAlignment.UnityARAlignmentGravity;
	public UnityARPlaneDetection planeDetection = UnityARPlaneDetection.None;

	[Header("Camera Settings Options")]
	public float farClipDist = 90.0f;
	public float fovAngle = 90.0f;

	[Header("Spectate Camera Options")]
	public float spectateCameraDistance = 8.0f;
	public float spectateCameraAngle = 30.0f;

	//htcTrackerRelayEnabled = true => Unity camera pose will be set to tracker pose every frame
	//public bool htcTrackerRelayEnabled = false;
	//htcTrackerOffsetEnabled = true => Unity camera pose will be set to ARKit pose + offset
	//This offset will be calculated upon calibration whenever the user chooses to calibrate.
	//public bool htcTrackerOffsetEnabled = true;

	
	public TrackingType tracking;

	//These may be used later if camera control (setting position and rotation equal to the tracker infromation) is done through this class
	private Vector4 tracker_position = new Vector4 (0, 0, 0, 1);
	private Quaternion tracker_rotation = new Quaternion (0, 0, 0, 0); // 0,1,0,0 is equal to pi rotation around X axis
	private Vector4 headset_position = new Vector4(0,0,0,1);
	private Quaternion headset_rotation = new Quaternion(1,0,0,0);
	private Vector4 arkit_position = new Vector4(0,1,-2,1);
	private Quaternion arkit_rotation = new Quaternion (0, 0, 0, 0);
	private Vector4 offset_position = new Vector4 (0, 0, 0, 0);
	private Quaternion offset_rotation = new Quaternion();
	private Vector3 arkitPosAC;
	private Quaternion arkitRotAC;
	


	// Use this for initialization
	void Start () {

		m_session = UnityARSessionNativeInterface.GetARSessionNativeInterface();
	
#if !UNITY_EDITOR
		//iOS

		tracking = TrackingType.TrackerCalibration;
		Application.targetFrameRate = 60;
        ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration();
		//config.planeDetection = planeDetection;
		//config.startAlignment = false;
		//config.getPointCloudData = false;
		//config.enableLightEstimation = false;
        m_session.RunWithConfig(config);

		if (m_camera == null) {
			m_camera = Camera.main;
		}
#else
		//UNITY EDITOR
		tracking = TrackingType.HeadsetRelay;
		//tracking = TrackingType.TrackerCalibration;

		ARKitSessionConfiguration sessionConfig = new ARKitSessionConfiguration (startAlignment, true, true);
		m_session.RunWithConfig(sessionConfig);

		//put some defaults so that it doesnt complain
		UnityARCamera scamera = new UnityARCamera ();
		scamera.worldTransform = new UnityARMatrix4x4 (new Vector4 (1, 0, 0, 0), new Vector4 (0, 1, 0, 0), new Vector4 (0, 0, 1, 0), new Vector4 (0, 0, 0, 1));
		Matrix4x4 projMat = Matrix4x4.Perspective (fovAngle, 1.33f, 0.1f, farClipDist);
		scamera.projectionMatrix = new UnityARMatrix4x4 (projMat.GetColumn(0),projMat.GetColumn(1),projMat.GetColumn(2),projMat.GetColumn(3));

		UnityARSessionNativeInterface.SetStaticCamera (scamera);

#endif
	}

	public void SetCamera(Camera newCamera)
	{
		if (m_camera != null) {
			UnityARVideo oldARVideo = m_camera.gameObject.GetComponent<UnityARVideo> ();
			if (oldARVideo != null) {
				savedClearMaterial = oldARVideo.m_ClearMaterial;
				Destroy (oldARVideo);
			}
		}
		SetupNewCamera (newCamera);
	}

	private void SetupNewCamera(Camera newCamera)
	{
		m_camera = newCamera;

        if (m_camera != null) {
            UnityARVideo unityARVideo = m_camera.gameObject.GetComponent<UnityARVideo> ();
            if (unityARVideo != null) {
                savedClearMaterial = unityARVideo.m_ClearMaterial;
                Destroy (unityARVideo);
            }
            unityARVideo = m_camera.gameObject.AddComponent<UnityARVideo> ();
            unityARVideo.m_ClearMaterial = savedClearMaterial;
        }
	}

	// Update is called once per frame


	//Edited by Chris 21/01/2018
	void Update () {
		
        if (m_camera != null)
        {
			//This is the original way of retrieving position and rotation from UnityARSessionNativeInterface
			//m_session.GetCameraPose(); retrieves the unaltered pose as estimated by ARKit.
			//Altering the pose here, in UnityARCameraManager, is simpler than attempting to do so in
			//UnityARSessionNativeInterface, as it does not require the position and rotation information to
			//be injected into the world transform matrix. 

            Matrix4x4 matrix = m_session.GetCameraPose();
			//#if !UNITY_EDITOR
			arkit_position = UnityARMatrixOps.GetPosition (matrix);
			arkit_rotation = UnityARMatrixOps.GetRotation (matrix);
			//#endif

			//It is instead possible to attempt to perform all camera adjustments below:

			Vector4 unityCameraPosition;
			Quaternion unityCameraRotation;

			//Debug.Log(tracking);

			if (tracking == TrackingType.TrackerRelay) {
				resetCameraParent();
				unityCameraPosition = tracker_position;
				unityCameraRotation = tracker_rotation;
			} else if (tracking == TrackingType.HeadsetRelay) {
				resetCameraParent();

				unityCameraPosition = headset_position;
				unityCameraRotation = headset_rotation;

				//Spectating mode - AR camera behind and above VR, looking down at scene
				CalculateSpectatePose(headset_position, headset_rotation, spectateCameraDistance, spectateCameraAngle,
										out unityCameraPosition, out unityCameraRotation);
				

			} else if (tracking == TrackingType.ARKit) {
				//Setting the Unity camera pose to purely ARKit's pose estimation
				resetCameraParent();
				unityCameraPosition = arkit_position;
				unityCameraRotation = arkit_rotation;
			} else {
				//NEW CALIBRATION
				//do not reset camera parent
				unityCameraPosition = arkit_position;
				unityCameraRotation = arkit_rotation;

				// OR TRY THIS 
				// resetCameraParent();
				// unityCameraPosition = arkit_position + offset_position;
				// unityCameraRotation = arkit_rotation * offset_rotation;
			}

			m_camera.transform.localPosition = unityCameraPosition;
			m_camera.transform.localRotation = unityCameraRotation;

			//TODO: Check whether the projectionMatrix is influenced by localposition and rotation
			//(But it shouldn't be, and we should not need to alter it)
			m_camera.projectionMatrix = m_session.GetCameraProjection ();
        }

	}


	/*
	 * calculates the position of the spectate camera - this is behind the VR player, looking down at him from an angle.
	 *
	 * angle: angle in degrees between horizontal plane and (SpectatePosition - VRPosition) 
	 * dist: how far behind the VR player the camera will be
	 *
	 * these two variables control how far behind the VR player the camera is, and how high it is.
	 */
	private void CalculateSpectatePose(Vector3 vrPos, Quaternion vrRot, float dist, float angle, out Vector4 spectatePosOut, out Quaternion spectateRotOut) {

		//Mathf works in radians 
		angle = angle * (Mathf.PI / 180);

		// These are back and up offsets
		float back = Mathf.Cos(angle) * dist;
		float up = Mathf.Sin(angle) * dist;

		//First get the y rotation of the angle and add 180 to it, construct a look vector from it.
		Quaternion lookToSpec = Quaternion.Euler(0.0f, vrRot.eulerAngles.y + 180.0f, 0.0f);
		//translate back behind the camera, translate up 
		Vector3 spectatePos = vrPos + (lookToSpec * (Vector3.forward * back)) + (Vector3.up * up);
		
		spectatePosOut = new Vector4(spectatePos.x, spectatePos.y, spectatePos.z, 1.0f);
		spectateRotOut = Quaternion.LookRotation(vrPos - spectatePos, Vector3.up);
	}



	/*
	//OLD CALIBRATION METHOD
	//calls the appropriate UnityARSessionNativeInterface method which attempts 
	//to calibrate the camera using the last known tracker position and rotation.
	//It would make sense to update tracker position before performing the offset calculations.
	//Therefore when the user presses the calibrate button, tracker pose should be sent to the AR device,
	//Followed by this routine being called. Otherwise outdated tracker pose may be used.
	public void calibrate() {
		//First retrieve ARKit's last world transform's position and rotation.
		Matrix4x4 matrix = m_session.GetCameraPose();

		Vector4 lastPosARKit = UnityARMatrixOps.GetPosition (matrix);
		Quaternion lastRotARKit = UnityARMatrixOps.GetRotation (matrix);
		Vector4 target_position;
		Quaternion target_rotation;

		if (tracking == TrackingType.TrackerCalibration) {
			target_position = tracker_position;
			target_rotation = tracker_rotation;
		} else {//if (tracking == TrackingType.HeadsetCalibration) {
			target_position = headset_position;
			target_rotation = headset_rotation * Quaternion.Euler(0,180,0);
			//Must rotate around y axis as phone and headset will face in opposite Z directions
			//When placed opposite each other for calibration.
		}

		//lastPosARKit.z = -lastPosARKit.z;

		//The offsets for position and rotation are trivially calculated.
		//Make sure target_position and lastPosARKit both have w set to 1.
		offset_position = target_position - lastPosARKit;
		offset_rotation = target_rotation * Quaternion.Inverse(lastRotARKit);
	}
	*/

	private void resetCameraParent() {
		m_camera.transform.parent.position = new Vector3();
		m_camera.transform.parent.rotation = new Quaternion();
	}

	//NEW CALIBRATION METHOD
	public void calibrate() {
		//get ARkit pose
		Matrix4x4 matrix = m_session.GetCameraPose();
		#if !UNITY_EDITOR
			Handheld.Vibrate();
		#endif

		Vector4 lastPosARKit = UnityARMatrixOps.GetPosition (matrix);
		Quaternion lastRotARKit = UnityARMatrixOps.GetRotation (matrix);

		arkitPosAC = lastPosARKit;
		arkitRotAC = lastRotARKit;

		Debug.Log("headset position: " + headset_position);
		Debug.Log("headset rotation: " + headset_rotation);

		Vector4 target_position;
		Quaternion target_rotation;

		if (tracking == TrackingType.TrackerCalibration) {
			target_position = tracker_position ;
			target_rotation = tracker_rotation;
		} else {//if (tracking == TrackingType.HeadsetCalibration) {

			//Must flip rotation because phone and headset are placed opposite each other for calibration.
			//target_rotation = headset_rotation;
			target_rotation = headset_rotation; //Quaternion.Euler(-headset_rotation.eulerAngles);
			target_position = headset_position ;

		}

		//Debug.Log(string.Format("Target pos: ({0:0.0}, {1:0.0}, {2:0.0})", target_position.x, target_position.y, target_position.z));
		//Debug.Log(string.Format("Target rot: ({0:000}, {1:000}, {2:000})", target_rotation.eulerAngles.x, target_rotation.eulerAngles.y, target_rotation.eulerAngles.z));
		


		//The offsets for position and rotation are trivially calculated.
		//Make sure target_position and lastPosARKit both have w set to 1.
		Vector3 cppos = target_position - lastPosARKit;
		Quaternion cprot =  target_rotation * Quaternion.Inverse(lastRotARKit);
		offset_position = cppos;
		offset_rotation = cprot;


		m_camera.transform.parent.position = cppos;
		m_camera.transform.parent.rotation = cprot;
		
	}

	public void updateHeadsetPosition(Vector4 pos) {
		headset_position = pos;
	}
	public void updateHeadsetRotation(Quaternion rot) {
		headset_rotation = rot;
	}

	public void updateTrackerPosition(Vector4 pos) {
		tracker_position = pos;
	}

	public void updateTrackerRotation(Quaternion rot) {
		tracker_rotation = rot;
	}
	public Vector4 getARKitPosition(){
		return arkit_position;
	}

	public Quaternion getARKitRotation(){
		return arkit_rotation;
	}

	public Vector3 getUnityCameraPosition() {
		if (m_camera != null) {
			return m_camera.transform.localPosition;
		}
		return new Vector3();
	}
	public Quaternion getUnityCameraRotation() {
		if (m_camera != null) {
			return m_camera.transform.localRotation;
		}
		return new Quaternion();
	}

	public Transform GetUnityCameraTransform() {
		if (m_camera != null) {
			return m_camera.transform;
		} else {
			Debug.Log("Cannot retrieve unity camera transform; main camera is null.");
			return null;
			//Return something other than null.
			//Transform does not have constructors...
		}
	}

}
