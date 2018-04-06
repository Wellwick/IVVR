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
    public int remainingSmallRunes;
    public int remainingLargeRunes;

    // Use this for initialization
    void Start () {
        //remaining number of each type of rune
        remainingSmallRunes = smallRunes.Length;
        remainingLargeRunes = largeRunes.Length;
        // figure out how many runes we have in total
        totalRunes = smallRunes.Length + largeRunes.Length;

        //select a random number of the starting runes of each type
        int startSR = Random.Range(0, System.Math.Min(startingRunes, smallRunes.Length));
        int startLR = startingRunes - startSR;
        
        //boolean arrays for which runes are to be activated at start
        bool[] SRflags = new bool[smallRunes.Length];
        bool[] LRflags = new bool[largeRunes.Length];

        //make boolean array with startSR number of true values
        int setSR = 0;
        while (setSR < startSR) // check if we have the correct number yet
        {
            //select a random position in the array
            int c = Random.Range(0, smallRunes.Length);
            //if it is not already set to true, set to true, and increment counter
            if (!SRflags[c])
            {
                SRflags[c] = true;
                setSR++;
            }
        }
        //make boolean array with startLR number of true values
        int setLR = 0;
        while (setLR < startLR)
        {
            int c = Random.Range(0, largeRunes.Length);
            if (!LRflags[c])
            {
                LRflags[c] = true;
                setLR++;
            }
        }
        // randomise which runes are already placed
        for (int i=0; i<smallRunes.Length; i++) {
			if (SRflags[i]) {
				smallRunes[i].GetComponent<Rune>().active = true;
				Activate(smallRunes[i]);
                //startSR--;
			} else {
				smallRunes[i].GetComponent<Rune>().active = false;
			}
		}
		for (int i=0; i<largeRunes.Length; i++) {
			if (LRflags[i]) {
				largeRunes[i].GetComponent<Rune>().active = true;
				Activate(largeRunes[i]);
                //startLR--;
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

        //decrement the remaining number of runes of this type
        if(rune.GetComponent<Rune>().type == Rune.runeType.LargeFixed || rune.GetComponent<Rune>().type == Rune.runeType.LargeGrab)
        {
            remainingLargeRunes--;
        }
        else if(rune.GetComponent<Rune>().type == Rune.runeType.SmallFixed || rune.GetComponent<Rune>().type == Rune.runeType.SmallGrab)
        {
            remainingSmallRunes--;
        }
	}


	public bool[] GetRuneState() {
		int count = 0;
		bool[] states = new bool[smallRunes.Length+largeRunes.Length];
		for (int i = 0; i<smallRunes.Length; i++) {
			states[i] = smallRunes[i].GetComponent<Rune>().active;
			count++;
		}
		for (int i = 0; i<largeRunes.Length; i++) {
			states[i+smallRunes.Length] = largeRunes[i].GetComponent<Rune>().active;
			count++;
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
