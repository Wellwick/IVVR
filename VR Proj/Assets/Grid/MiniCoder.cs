using UnityEngine;
using UnityEditor;
using System;

public class MiniCoder {

    private byte[] buff;

    public MiniCoder(int x, int y, int z)
    {
        buff = new byte[12];
        writeIn(x, 0);
        writeIn(y, 4);
        writeIn(z, 8);
    }

    public MiniCoder(float posX, float posY, float posZ, float rotX, float rotY, float rotZ, float rotW)
    {
        buff = new byte[28];
        writeIn(posX, 0);
    }

    // Constructor with a starting array
    public MiniCoder(byte[] array)
    {
        buff = array;
    }

    // Method to return the byte buffer
    public byte[] GetArray()
    {
        return buff;
    }

    public int GetX()
    {
        return readOutInt(0);
    }

    public int GetY()
    {
        return readOutInt(4);
    }

    public int GetZ()
    {
        return readOutInt(8);
    }
    
    public Vector3 getPos()
    {
        return new Vector3(readOutFloat(0), readOutFloat(4), readOutFloat(8));
    }

    public Quaternion getRot()
    {
        return new Quaternion(readOutFloat(12), readOutFloat(16), readOutFloat(20), readOutFloat(24));
    }

    // Method for converting an int to a byte array and outputting to the buffer
    private void writeIn(int value, int pos)
    {
        byte[] writeIn = BitConverter.GetBytes(value);
        // Need to allocate each byte position for correct deserialization
        for (int i = 0; i < writeIn.Length; i++)
        {
            buff[i + pos] = writeIn[i];
        }
    }

    private void writeIn(float value, int pos)
    {
        byte[] writeIn = BitConverter.GetBytes(value);
        
        for (int i = 0; i < writeIn.Length; i++)
        {
            buff[i + pos] = writeIn[i];
        }
    }

    // Method to read out an integer from 4 bytes in the buffer from a given position
    public int readOutInt(int pos)
    {
        return BitConverter.ToInt32(buff, pos);
    }
    
    public float readOutFloat(int pos)
    {
        return BitConverter.ToSingle(buff, pos);
    }

}
