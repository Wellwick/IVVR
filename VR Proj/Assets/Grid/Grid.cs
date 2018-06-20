using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public int width, height, depth;
    public GameObject cube;
    private GameObject[,,] cubes;
    

	// Use this for initialization
	void Start () {
        cubes = new GameObject[width, height, depth];
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < depth; z++)
            {
                AddCube(x, 0, z);
            }
        }

	}
	
    public void AddCube(int x, int y, int z)
    {
        if (x < width && x >= 0 && y < height && y >= -1 && z < depth && z >= 0)
        {
            GameObject cell = GameObject.Instantiate(cube, new Vector3(transform.position.x + (0.2f * x), transform.position.y + (0.2f * y), transform.position.z + (0.2f * z)), new Quaternion());
            if (y >= 0)
                cubes[x, y, z] = cell;

            bool above = y < height - 1 && cubes[x, y + 1, z] == null;
            bool below = y > 0          && cubes[x, y - 1, z] == null;
            bool front = z < depth - 1  && cubes[x, y, z + 1] == null;
            bool back = z > 0           && cubes[x, y, z - 1] == null;
            bool right = x < width - 1  && cubes[x + 1, y, z] == null;
            bool left = x > 0           && cubes[x - 1, y, z] == null;

            cell.GetComponent<Cube>().SetCoord(x, y, z, above, below, front, back, right, left);

            // Need to go over surrounding cells and remove relevant colliders
            if (y < height - 1 && cubes[x, y + 1, z] != null)
            {
                cubes[x, y + 1, z].GetComponent<Cube>().below.SetActive(false);
            }

            if (y > 0 && cubes[x, y - 1, z] != null)
            {
                cubes[x, y - 1, z].GetComponent<Cube>().above.SetActive(false);
            }

            if (z < depth - 1 && cubes[x, y, z + 1] != null)
            {
                cubes[x, y, z + 1].GetComponent<Cube>().back.SetActive(false);
            }

            if (z > 0 && cubes[x, y, z - 1] != null)
            {
                cubes[x, y, z - 1].GetComponent<Cube>().front.SetActive(false);
            }

            if (x < width - 1 && cubes[x + 1, y, z] != null)
            {
                cubes[x + 1, y, z].GetComponent<Cube>().left.SetActive(false);
            }

            if (x > 0 && cubes[x - 1, y, z] != null)
            {
                cubes[x - 1, y, z].GetComponent<Cube>().right.SetActive(false);
            }
        }
    }

	public bool CubeExists(int x, int y, int z)
    {
        if (x < width && x >= 0 && y < height && y >= -1 && z < depth && z >= 0)
        {
            return cubes[x, y, z] != null;
        } else
        {
            return false;
        }
    }
}
