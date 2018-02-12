using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour {
	public enum runeType : byte {
		SmallGrab = 0,
		LargeGrab = 1,
		SmallFixed = 2,
		LargeFixed = 3
	}

	public runeType type;
	public bool active = false;
	private Henge henge;

	// Use this for initialization
	void Start () {
		henge = GameObject.Find("Henge").GetComponent<Henge>();
		if (henge == null) {
			Debug.LogError("Couldn't find the Henge for " + gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// If we are a grab-able, check whether we intersect a fixed rune
		// of the correct type?
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("We got a collision!");
		// Because this is a trigger collision, it means other.gameObject is the 
		// grab-able rune
		if (active) return; //if we are already active, return
		Rune otherRune;
		switch (type) {
		case runeType.LargeFixed:
			//only care if other is LargeGrab
			otherRune = other.gameObject.GetComponent<Rune>();
			if (otherRune.type == runeType.LargeGrab) {
				// Delete other and active this
				henge.Activate(gameObject);
				Destroy(other.gameObject);
			}
			break;
		case runeType.SmallFixed:
			//only care if other is SmallGrab
			otherRune = other.gameObject.GetComponent<Rune>();
			if (otherRune.type == runeType.SmallGrab) {
				// Delete other and active this
				henge.Activate(gameObject);
				//drop the item if it was being dragged
				Grappler left = GameObject.Find("Controller (left)").GetComponent<Grappler>();
				Grappler right = GameObject.Find("Controller (right)").GetComponent<Grappler>();
				if (right.CheckObject(other.gameObject)) {
					right.ReleaseObject();
				}
				if (left.CheckObject(other.gameObject)) {
					left.ReleaseObject();
				}
				Destroy(other.gameObject);
			}
			break;

		}
	}
}
