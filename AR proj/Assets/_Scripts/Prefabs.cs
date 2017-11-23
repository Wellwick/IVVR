using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour {

	public enum PID : int {
		Cube,
		Ball,
		Brick,
		Fire
	}

	public GameObject[] prefabs = new GameObject[Enum.GetNames(typeof(PID)).Length];
}
