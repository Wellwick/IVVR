using UnityEngine;
using UnityEditor;
using System;
public class Coder{

    /*
     * A class to encode and decode a byte buffer which can be communicated over a 
     * Unity NetworkTransport layer.
     *
     * Each item in the buffer is treated as a GameObject which has an associated ID
     * and AssetID. The GameObject's Transform can also be transmitted within the
     * packet, with position, rotation and velocity accessible on receiving.
     */
    private byte[] buff;
    private byte count;
    private int size;
    // Constructor for a given buffer length
    public Coder(int size){
        buff = new byte[size];
        count = 0;
        this.size = size;
    }

    // Constructor with a starting array
    // Can be used to replicate a Coder
    public Coder(byte[] array) {
        buff = array;
        count = buff[0];
        size = array.Length;
    }

    // Method to return the byte buffer
    public byte[] getArray() {
        // The count must be stored at the beginning of the array so that the receiving Coder knows
        // how many items are stored within
        buff[0] = count;
        return buff;
    }

    // Method to return the count of items in the Coder
    public byte getCount(){
        return count;
    }

    // Method to test whether there is no remaining space for items in the Coder class
    public bool isFull() {
        return ((((count+1)*49)+1)>size);
    }

    // Method to add serialisation of a given message item
    // Works under the assumption that all items in the buffer are the same size and have an attached Transform
    public void addSerial(byte type, int id, int assetId, Transform transform){
        // Tests whether there is space remaining in the Coder for a new serialized item
        if (isFull()) {
            Debug.LogError("Coder array is already full, can't add type " + type + " object id " + id);
            return;
        }
        // The index is used to find the location in the buffer to write each component of information
        // The count must be incremented after getting the index so that the next item can be added at the correct place
        int index = 1 + (count++*49);
        buff[index] = type;
        writeIn(id, index+1);
        writeIn(assetId, index+5);
        if(transform == null){
            return;
        }
        //setup for position
        Vector3 pos = transform.position;
        writeIn(pos.x, index+9);
        writeIn(pos.y, index+13);
        writeIn(pos.z, index+17);

        //setup for rotation
        Quaternion rot = transform.rotation;
        writeIn(rot.x, index+21);
        writeIn(rot.y, index+25);
        writeIn(rot.z, index+29);
        writeIn(rot.w, index+33);

        //setup for velocity
        Rigidbody rb = transform.GetComponent<Rigidbody>();
        if (rb == null) {
            return;
        }
        Vector3 vel = rb.velocity;
        writeIn(vel.x, index+37);
        writeIn(vel.y, index+41);
        writeIn(vel.z, index+45);

    }

    // Method for converting an int to a byte array and outputting to the buffer
    private void writeIn(int value, int pos) {
        byte[] writeIn = BitConverter.GetBytes(value);
        // Need to allocate each byte position for correct deserialization
        for (int i = 0; i < writeIn.Length; i++) {
            buff[i+pos] = writeIn[i];
        }
    }
    
    // Method for converting a float to a byte array and outputting to the buffer
    private void writeIn(float value, int pos) {
        byte[] writeIn = BitConverter.GetBytes(value);
        // Need to allocate each byte position for correct deserialization
        for (int i = 0; i < writeIn.Length; i++) {
            buff[i+pos] = writeIn[i];
        }
    }

    // Method to read out an integer from 4 bytes in the buffer from a given position
    public int readOutInt(int pos) {
        return BitConverter.ToInt32(buff, pos);
    }

    // Method to read out a float from 4 bytes in the buffer from a given position
    public float readOutFloat(int pos) {
        return BitConverter.ToSingle(buff,pos);
    }

    // Method to get the type of a packet item, given an item index
    public byte GetType(int index) {
        if(illegalVal(index)){
            return 255;
        }
        //move the index to correct position
        index = 1 + (index*49);

        return buff[index];
    }

    // Method to get ID of an item, given an item index
    public int GetID(int index) {
        if(illegalVal(index)){
            return -2;
        }
        //move the index to correct position
        index = 1 + (index*49);

        return readOutInt(index+1);
    }

    // Method to get AssetID of an item, given an item index
    public int GetAssetID(int index) {
        if(illegalVal(index)){
            return -2;
        }
        //move the index to correct position
        index = 1 + (index*49);

        return readOutInt(index+5);
    }

    // Method to get Position of an item, given an item index
    public Vector3 GetPosition(int index) {
        if(illegalVal(index)){
            return new Vector3(0,0,0);
        }
        //move the index to correct position
        index = 1 + (index*49);

        //we already have the array
        //sort out in a sec
        float posX = readOutFloat(index+9);
        float posY = readOutFloat(index+13);
        float posZ = readOutFloat(index+17);
        return new Vector3(posX, posY, posZ);
    }

    // Method to get Rotation of an item, given an item index
    public Quaternion GetRotation(int index) {
        index = 1 + (index*49);
        float rotX = readOutFloat(index+21);
        float rotY = readOutFloat(index+25);
        float rotZ = readOutFloat(index+29);
        float rotW = readOutFloat(index+33);
        return new Quaternion(rotX, rotY, rotZ, rotW);

    }

    // Method to get Velocity of an item, given an item index
    public Vector3 GetVelocity(int index) {
        if(illegalVal(index)){
            return new Vector3(0,0,0);
        }
        //move the index to correct position
        index = 1 + (index*49);

        //once again, already have the array
        float velX = readOutFloat(index+37);
        float velY = readOutFloat(index+41);
        float velZ = readOutFloat(index+45);

        return new Vector3(velX, velY, velZ);
    }

    // Method to test whether a given index is out of range of the Coder's buffer
    private bool illegalVal(int index) {
        if (index > buff[0]) {
            Debug.LogError("Coded message count does not reach value " + index);
            return true;
        }
        return false;
    }

}
