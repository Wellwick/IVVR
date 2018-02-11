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

	// Use this for initialization
	void Start () {
		// figure out how many runes we have in total
		totalRunes = smallRunes.Length + largeRunes.Length;
		// randomise which runes are already placed
		for (int i=0; i<smallRunes.Length; i++) {
			if (startingRunes>0) {
				smallRunes[i].GetComponent<Rune>().active = true;
				Activate(smallRunes[i]);
				startingRunes--;
			} else {
				smallRunes[i].GetComponent<Rune>().active = false;
			}
		}
		for (int i=0; i<largeRunes.Length; i++) {
			if (startingRunes>0) {
				largeRunes[i].GetComponent<Rune>().active = true;
				Activate(largeRunes[i]);
				startingRunes--;
			} else {
				largeRunes[i].GetComponent<Rune>().active = false;
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
		activeRunes++;
		rune.GetComponent<Rune>().active = true;
	}


	public bool[] GetRuneState() {
		bool[] states = new bool[smallRunes.Length+largeRunes.Length];
		for (int i = 0; i<smallRunes.Length; i++) {
			states[i] = smallRunes[i].GetComponent<Rune>().active;
		}
		for (int i = 0; i<largeRunes.Length; i++) {
			states[i+smallRunes.Length] = largeRunes[i].GetComponent<Rune>().active;
		}
		return states;
	}

	//used on the AR end to set an updated set of runes
	public void SetRuneState(bool[] states) {
		for (int i = 0; i<smallRunes.Length; i++) {
			if (states[i] && !smallRunes[i].GetComponent<Rune>().active) {
				Activate(smallRunes[i]);
			}
		}
		for (int i = 0; i<largeRunes.Length; i++) {
			if (states[i+smallRunes.Length] && !largeRunes[i].GetComponent<Rune>().active) {
				Activate(largeRunes[i]);
			}
		}
	}

	public int getSize() {
		return totalRunes;
	}
}
