﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henge : MonoBehaviour {

	public GameObject[] smallRunes;
	public GameObject[] largeRunes;
	public GameObject baseRune;
	public GameObject portal;
	public GameObject largeDrop;
	public GameObject smallDrop;

	public Material properMaterial;
    public Material transparentMaterial;
	public int startingRunes = 6;
    public int verbose = 0;
	private int activeRunes = 0;
	private int totalRunes;

	// Use this for initialization
	void Start () {
	}

    public void Reset()
    {
        Reset(startingRunes);
    }

    public void Reset(int startingRunes)
    {
        // Deactivate the portal!
        MeshRenderer mr = baseRune.GetComponent<MeshRenderer>();
        Material[] mats = mr.materials;
        mats[0] = transparentMaterial;
        mr.materials = mats;
        portal.SetActive(false);

        gameObject.SetActive(true);

        Debug.Log("Resetting Runes: Starting with already active: " + startingRunes);

        // figure out how many runes we have in total
        totalRunes = smallRunes.Length + largeRunes.Length;
        // start off all of them false
        for (int i = 0; i < smallRunes.Length; i++)
        {
            smallRunes[i].GetComponent<Rune>().active = false;
        }
        for (int i = 0; i < largeRunes.Length; i++)
        {
            largeRunes[i].GetComponent<Rune>().active = false;
        }

        // randomise which runes are already placed
        int tempCounter = totalRunes;
        while (startingRunes > 0)
        {
            int selection = (int)Random.Range(0.0f, tempCounter - 0.1f);
            Log("Selection value was set to " + selection);
            // step through and reduce until we reach the selection value
            for (int i = 0; i < smallRunes.Length; i++)
            {
                if (selection == 0 && smallRunes[i].GetComponent<Rune>().active == false)
                {
                    Activate(smallRunes[i]);
                    selection--;
                    break;
                }
                else
                {
                    if (smallRunes[i].GetComponent<Rune>().active == false)
                    {
                        selection--;
                    }
                }
            }

            for (int i = 0; i < largeRunes.Length; i++)
            {
                if (selection == -1) break;
                if (selection == 0 && largeRunes[i].GetComponent<Rune>().active == false)
                {
                    Activate(largeRunes[i]);
                    break;
                }
                else
                {
                    if (largeRunes[i].GetComponent<Rune>().active == false)
                    {
                        selection--;
                    }
                }
            }
            startingRunes--;
            tempCounter--;
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
	public void Activate(GameObject rune)
    {
        Log("Activating Rune");
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

    public bool IsComplete()
    {
        return (activeRunes == totalRunes);
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

	public GameObject GetItemDrop() {
        /* Removed this because a death during pause means that an enemy should drop a rune
         * This likely means that transient damage arrived after a pause had been started
        if (GameObject.FindObjectOfType<GameManager>().GetGameState() != GameState.Active)
            return null;
        */

		int smallDrops = 0;
		int largeDrops = 0;

		for (int i = 0; i < smallRunes.Length; i++) {
			if (!smallRunes[i].GetComponent<Rune>().active)
				smallDrops++;
		}
		for (int i = 0; i < largeRunes.Length; i++) {
			if (!largeRunes[i].GetComponent<Rune>().active)
				largeDrops++;
		}

		if (smallDrops+largeDrops == 0) {
			return null;
		} else {
			int spawn = (int)Random.Range(0.0f, smallDrops+largeDrops-0.1f)+1;
			if (largeDrops == 0 || spawn < smallDrops) {
				return smallDrop;
			} else {
				return largeDrop;
			}
		}
	}

    private void Log(string s)
    {
        if (verbose > 0)
        {
            Debug.Log(s);
        }
    }
}
