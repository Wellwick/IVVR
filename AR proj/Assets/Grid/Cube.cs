using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    private int x, y, z;
    public GameObject above, below, front, back, left, right;

    public void SetCoord(int x, int y, int z,
        bool above, bool below, bool front, 
        bool back, bool right, bool left)
    {
        this.x = x;
        this.y = y;
        this.z = z;

        this.above.SetActive(above);
        this.below.SetActive(below);
        this.front.SetActive(front);
        this.back.SetActive(back);
        this.left.SetActive(left);
        this.right.SetActive(right);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetX() { return x; }
    public int GetY() { return y; }
    public int GetZ() { return z; }
}
