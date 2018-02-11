using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henge : MonoBehaviour {

	public GameObject[] smallRunes;
	public GameObject[] largeRunes;
	public GameObject baseRune;
	public GameObject portal;

	public Material properMaterial;
	public int startingRunes = 3;
	private int activeRunes = 0;
	private int totalRunes;

	private Dictionary<GameObject, bool> active;

	// Use this for initialization
	void Start () {
		// figure out how many runes we have in total
		totalRunes = smallRunes.Length + largeRunes.Length;
		// randomise which runes are already placed
		active = new Dictionary<GameObject, bool>();
		for (int i=0; i<smallRunes.Length; i++) {
			if (startingRunes>0) {
				active.Add(smallRunes[i], true);
				Activate(smallRunes[i]);
				startingRunes--;
			} else {
				active.Add(smallRunes[i], false);
			}
		}
		for (int i=0; i<largeRunes.Length; i++) {
			if (startingRunes>0) {
				active.Add(largeRunes[i], true);
				Activate(largeRunes[i]);
				startingRunes--;
			} else {
				active.Add(largeRunes[i], false);
			}
		}
		portal.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (totalRunes == activeRunes) {
			// Activate the portal!
			MeshRenderer mr = baseRune.GetComponent<MeshRenderer>();
			Material[] mats = mr.materials;
			mats[0] = properMaterial;
			mr.materials = mats;
			portal.SetActive(true);
		}
	}

	//should only need to be called once per rune
	public void Activate(GameObject rune) {
		//activation is simply changing the material
		MeshRenderer mr = rune.GetComponent<MeshRenderer>();
		//need to change the array, instead of a single value
		Material[] mats = mr.materials;
		mats[0] = properMaterial;
		mr.materials = mats;
		//set the dictionary value to true, just in case it hasn't already been set
		active[rune] = true;
		activeRunes++;
	}


	public bool[] GetRuneState() {
		bool[] states = new bool[smallRunes.Length+largeRunes.Length];
		for (int i = 0; i<smallRunes.Length; i++) {
			active.TryGetValue(smallRunes[i], out states[i]);
		}
		for (int i = 0; i<largeRunes.Length; i++) {
			active.TryGetValue(largeRunes[i], out states[i+smallRunes.Length]);
		}
		return states;
	}

	//used on the AR end to set an updated set of runes
	public void SetRuneState(bool[] states) {

	}
}
