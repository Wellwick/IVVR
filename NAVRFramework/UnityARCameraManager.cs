using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

// Enum containing all types of pose estimation
// These are not native to ARKit or Unity; they were developed by Krzysztof Janusiewicz (Chris)
public enum TrackingType : byte {
	ARKit = 0,
	TrackerRelay = 1,
	HeadsetRelay = 2,
	TrackerCalibration = 3,
	HeadsetCalibration = 4
}


/* 
 * EXTREMELY IMPORTANT CLASS FOR AR CAMERA MANAGEMENT
 * ------------------
 *
 * This is an iOS only implementation
 *
 * ------------------
 *
 * Originally developed by Unity as part of the Unity ARKit plugin.
 * https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-arkit-plugin-92515 
 * 
 * ------------------
 *
 * Edited by Chris/Krzysztof to implement different types of pose estimation that make use
 * of the HTC Vive Lighthouse tracking system. ARKit's internal pose estimation is enhanced
 * through the ability to CALIBRATE to HTC Vive's accurate positional tracking. Another
 * feature is Tracker and Headset Relay; these simply set the AR position and rotation to 
 * the last known pose of the Tracker/Headset. Headset relay can be used to provide the AR
 * user with the VR user's Point of View (PoV), while tracker relay can be used for ultra
 * accurate pose estimation which is not susceptible to the rapid build up of error that
 * dead-reckoning is (ARKit's method).
 *
 * ------------------
 * 
 * Instructions for use with iOS:
 *  - Follow Unity ARKit instructions in the TUTORIAL.txt file included with Unity ARKit to
 *		set up the default ARKit. 
 *  - Replace the default UnityARCameraManager with this version.
 *  - OPTIONAL: allow the user to change pose estimation method (TrackingType).
 *  - Configure NetworkManager and NetworkInterface to receive Vive Headset and Tracker
 * 		pose, and update Headset and Tracker position and rotation in this class through
 *		the provided functions, updateHeadsetRotation(Quaternion q) etc.
 * 
 * Instructions for Android:
 * A similar wrapper must be found for Unity mobile AR; it can then be edited to allow for
 * HTC Vive lighthouse positional tracking to enhance quality of pose estimation and to
 * interface with NetworkManager through NetworkInterface.
 */
public class UnityARCameraManager : MonoBehaviour {

    public Camera m_camera;

	[Header("Pose Estimation Options")]
	public TrackingType tracking = TrackingType.ARKit;

	[Header("ARKit Config Options")]
	public UnityARAlignment startAlignment = UnityARAlignment.UnityARAlignmentGravity;
	public UnityARPlaneDetection planeDetection = UnityARPlaneDetection.None;
	public bool getPointCloud = false;
	public bool enableLightEstimation = true;

    private UnityARSessionNativeInterface m_session;
	private Material savedClearMaterial;


	/*
	 * Keep last known position and rotation of each of the following:
	 *  - tracker
	 *  - headset
	 * 	- internal ARKit pose estimate
	 * These are used for the different types of pose estimation.
	 * They are private but are exposed through getter methods inside the class.
	 */
	private Vector4 tracker_position = new Vector4 (0, 0, 0, 1);
	private Quaternion tracker_rotation = new Quaternion (1, 0, 0, 0); // 0,1,0,0 is equal to pi rotation around X axis
	private Vector4 headset_position = new Vector4(0, 0, 0, 1);
	private Quaternion headset_rotation = new Quaternion(1, 0, 0, 0);
	private Vector4 arkit_position;
	private Quaternion arkit_rotation;



	// Use this for initialization
	void Start () {

		m_session = UnityARSessionNativeInterface.GetARSessionNativeInterface();
	
#if UNITY_EDITOR
		//UNITY EDITOR

		// Set tracking to Tracker or Headset Relay; Calibration/ARKit are not suitable
		// in the Unity Editor as it lacks 6DoF tracking
		tracking = TrackingType.TrackerRelay;

		//put some defaults so that it doesn't complain
		UnityARCamera scamera = new UnityARCamera ();
		scamera.worldTransform = new UnityARMatrix4x4 (new Vector4 (1, 0, 0, 0), new Vector4 (0, 1, 0, 0), new Vector4 (0, 0, 1, 0), new Vector4 (0, 0, 0, 1));
		Matrix4x4 projMat = Matrix4x4.Perspective (60.0f, 1.33f, 0.1f, 30.0f);
		scamera.projectionMatrix = new UnityARMatrix4x4 (projMat.GetColumn(0),projMat.GetColumn(1),projMat.GetColumn(2),projMat.GetColumn(3));

		UnityARSessionNativeInterface.SetStaticCamera (scamera);
#else 
	//iOS
		Application.targetFrameRate = 60;
        ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration();
		
		config.planeDetection = planeDetection;
		config.startAlignment = startAlignment;
		config.getPointCloudData = false;
		config.enableLightEstimation = true;
        m_session.RunWithConfig(config);

		if (m_camera == null) {
			m_camera = Camera.main;
		}
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
	// Heavily edited from original ARKit implementation (included below, commented out)
	void Update () {
		
        if (m_camera != null) {
			//This is the original way of retrieving position and rotation from UnityARSessionNativeInterface
			//m_session.GetCameraPose(); retrieves the unaltered pose as estimated by ARKit.
			//Altering the pose here, in UnityARCameraManager, is simpler than attempting to do so in
			//UnityARSessionNativeInterface, as it does not require the position and rotation information to
			//be injected into the world transform matrix. 

            Matrix4x4 matrix = m_session.GetCameraPose();
			arkit_position = UnityARMatrixOps.GetPosition (matrix);
			arkit_rotation = UnityARMatrixOps.GetRotation (matrix);

			//It is instead possible to attempt to perform all camera adjustments below:

			Vector4 unityCameraPosition;
			Quaternion unityCameraRotation;

			//Log(tracking);

			if (tracking == TrackingType.TrackerRelay) {
				resetCameraParent();
				unityCameraPosition = tracker_position;
				unityCameraRotation = tracker_rotation;
			} else if (tracking == TrackingType.HeadsetRelay) {
				resetCameraParent();
				unityCameraPosition = headset_position;
				unityCameraRotation = headset_rotation;

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
			}

			m_camera.transform.localPosition = unityCameraPosition;
			m_camera.transform.localRotation = unityCameraRotation;

			//TODO: Check whether the projectionMatrix is influenced by localposition and rotation
			//(But it shouldn't be, and we should not need to alter it)
			m_camera.projectionMatrix = m_session.GetCameraProjection ();
        }

	}

	/* 
	// Original Update() method
	void Update () {
        if (m_camera != null)
        {
            // JUST WORKS!
            Matrix4x4 matrix = m_session.GetCameraPose();
			m_camera.transform.localPosition = UnityARMatrixOps.GetPosition(matrix);
			m_camera.transform.localRotation = UnityARMatrixOps.GetRotation (matrix);

            m_camera.projectionMatrix = m_session.GetCameraProjection ();
        }
	}
	*/

	// Must reset the offset applied to the parent of the unity camera if mode is not calibration
	private void resetCameraParent() {
		m_camera.transform.parent.position = new Vector3();
		m_camera.transform.parent.rotation = new Quaternion();
	}

	/*
	 * NEW CALIBRATION METHOD
	 * This uses last known headset/tracker position and rotation to calculate an offset
	 * and apply it to the CameraParent GameObject.
	 * In previous calibration methods it would store the offset and transform it by
	 * ARKit's internal pose estimation, saving the result
	 * straight to the Unity Camera object.
	 */
	public void calibrate() {
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
			target_rotation = headset_rotation;
			//Quaternion.Euler(-headset_rotation.eulerAngles);

			/* 
			 * TODO: 
			 * Rotate around y axis as phone and headset will face in opposite Z directions
			 * when placed opposite each other for calibration. To calibrate using this
			 * method, the AR screen must face the headset during calibration, making it
			 * difficult to press the clibration button.
			 */
		}

		//The offsets for position and rotation are trivially calculated.
		//Make sure target_position and lastPosARKit both have w set to 1.
		Vector3 cppos = target_position - lastPosARKit;
		Quaternion cprot =  target_rotation * Quaternion.Inverse(lastRotARKit);
		
		//Apply offset to the parent of the GameObject which contains the camera.
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

	public Transform GetUnityCameraTransform() {
		if (m_camera != null) {
			return m_camera.transform;
		} else {
			Debug.Log("Cannot retrieve unity camera transform; main camera is null.");
			return null;
			//Try returning something other than null.
			//Transform does not have constructors...
		}
	}

}
