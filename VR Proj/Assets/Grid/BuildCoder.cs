using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCoder : Coder {

	public BuildCoder(int size) : base(size) {  }
    public BuildCoder(byte[] array) : base(array) {  }

    public void AddCube(int x, int y, int z)
    {
        byte type = (byte)BuildNetwork.MessageIdentity.Type.Spawn;
        int index = 1 + (getCount() * 49);
        addSerial(type, -1, -1, null);

        //setup for position
        writeIn(x, index + 9);
        writeIn(y, index + 13);
        writeIn(z, index + 17);
    }

    public int GetX(int index)
    {
        return readOutInt(1 + (index* 49) + 9);
    }

    public int GetY(int index)
    {
        return readOutInt(1 + (index * 49) + 13);
    }

    public int GetZ(int index)
    {
        return readOutInt(1 + (index * 49) + 17);
    }
}
