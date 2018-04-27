using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * NETWORKINTERFACE.CS
 * ----------------------------
 * This script acts as an interface between the AR scene, native ARKit functions and
 * NetworkManager. It must be attached to a GameObject in the AR scene, and provides
 * static functions that AR NetworkManager can easily access. Generally speaking, it
 * is a helper class
 *
 * ----------------------------
 * EXAMPLES
 * ----------------------------
 * IP Address Retrieval
 *
 * NetworkManager retrieves server IP address entered by user in the InputField in the UI.
 * In NetworkManager:
 *
 * 		String ipAddress = NetworkInterface.getIPAddressInput();
 *
 * ----------------------------
 * AR Camera Transform Retrieval
 *
 * NetworkManager retrieves the position and rotation of the Unity camera in the scene.
 * In NetworkInterface:
 *
 *		ARCameraManager.GetUnityCameraTransform();
 *
 * In NetworkManager:
 *
 * 		NetworkInterface.GetUnityCameraTransform();
 *
 * ----------------------------
 * Updating VR Controlled Objects 
 *
 * NetworkManager receives information sent by the VR Server, such as Tracker Pose.
 * NetworkInterface can be used to pass this information to TextManager to display as
 * debug, or to UnityARCameraManager to use for pose estimation.
 * In NetworkInterface:
 *
 *		ARCameraManager.updateTrackerRotation (rot);
 *		textManager.updateTrackerRotationString (rot);
 *
 * In NetworkManager:
 *
 *		NetworkInterface.UpdateTrackerPose(pos, rot);
 *
 */


public class NetworkInterface : MonoBehaviour {

	/*
	 * These public GameObjects are used to link objects in the scene to an instance of
	 * this class. It is possible but not necessary to check whether these elements
	 * are equal to null before using them; this could be used to display debug error
	 * messages notifying the developer that objects have not been linked in the Unity
	 * scene; this could be done in the Start method.
	 */

	[Header("UI Elements")]
	public GameObject IPinputFieldObject;

	[Header("VR Controlled Objects")]
	public GameObject VRPlayer;
	/* 
	 * VR CONTROLLED OBJECTS
	 * Add any GameObjects here which are controlled by VR and must be synchronised across
	 * the two scenes. These are declared public so that they can be linked to objects in
	 * the AR scene in the editor. Any information received by the NetworkManager that is
	 * not synchronised automatically such as transform (position, rotation, scale), must
	 * be synchronised manually here using helper functions such as altering the health of
	 * the VR Player for example: VRPlayer.setHealth(100);
	 */

	[Header("AR Controlled Objects")]
	/* 
	 * AR CONTROLLED OBJECTS
	 * Similar to VR Controlled objects, add any GameObjects here which are controlled by
	 * AR and must be synchronised across the two scenes. These are declared public so
	 * that they can be linked to objects in the AR scene in the editor. NetworkManager
	 * can then retrieve information from these using methods in NetworkInterface and
	 * send it to the VR server.
	 */

	
	private static Text IPinputField;
	private static UnityARCameraManager ARCameraManager;
	private static TextManager textManager;
	/* These private static objects are used to reference object in the AR scene instead
	 * of calling GameObject.GetComponent<Type>() or GameObject.FindObjectOfType<Type>()
	 * every time they are needed.
	 */


	/*
	 * This function is called on the frame when a script is enabled just before any of
	 * the Update methods is called the first time. Here, any static objects that are
	 * needed must be fetched from either the scene directly with any of the following
	 * commands, or through the linked public GameObjects.
	 * Examples are shown in the method.
	 */

	void Start() {

		
		ARCameraManager = GameObject.FindObjectOfType<UnityARCameraManager>();
		textManager = GameObject.FindObjectOfType<TextManager> ();
		/*
		 * Finding the UnityARCameraManager script:
		 * Finding the TextManager script:
		 * This is possible because it is unique; only one instance exists in the scene.
		 * The result of the static function GameObject.FindObjectOfType is allocated
		 * to the static UnityARCameraManager object so that it can easily be used
		 * within this class.
		 */

		IPinputField = IPinputFieldObject.GetComponent<Text>();
		/*
		 * Finding the input field Text object which an IP address is typed into:
		 * This is possible because the GameObject IPinputFieldObject has a component
		 * of type Text. It can be retrieved using the dynamic function GetComponent<Text>
		 */	

	}

	/*
	 * This function is called on every frame update. Methods can be called here which
	 * synchronise the AR and VR scenes together (facilitated by NetworkManager), however
	 * this can also be done in NetworkManager.Update().
	 */
	void Update() {
		
	}

	/*
	 * NetworkManager can call this method to display debug information directly to the UI
	 * This is enabled by linking the textManager object which controls the debug text
	 * displayed in the interface. Similar functionality can be used in other methods, 
	 * such as displaying the position of the VR headset or tracker in the UI when it is
	 * received
	 */
	public static void UpdateNetworkStatus(string status) {
		textManager.updateNetworkString (status);
	}

	
	// Called by NetworkManager to retrieve AR pose and send it back to the VR server
	public static Transform GetCameraTransform() {
		return ARCameraManager.GetUnityCameraTransform();
	}

	// Called by NetworkManager to update VR Tracker position
	public static void UpdateTrackerPose(Vector3 pos, Quaternion rot) {

		/*
		 * Using the linked UnityARCameraManager to update the VR tracker position
		 * Alternatively, a separate VR Tracker Object could be placed in the scene and
		 * had its pose updated here. UnityARCameraManager would then retrieve this
		 * position and rotation from there.
		 */
		ARCameraManager.updateTrackerPosition (pos);
		ARCameraManager.updateTrackerRotation (rot);

		// Using the linked textmanager to display tracker pose information in the UI
		textManager.updateTrackerPositionString (pos);
		textManager.updateTrackerRotationString (rot);
	}

	// See UpdateTrackerPose
	public static void UpdateHeadsetPose(Vector3 pos, Quaternion rot) {
		ARCameraManager.updateHeadsetPosition (pos);
		ARCameraManager.updateHeadsetRotation (rot);
	}
	
	/*
	 * Used by NetworkManager to retrieve server IP address entered by user in the
	 * InputField in the UI.
	 */
	public static string getIPAddressInput() {
		return IPinputField.text;
	}
}
