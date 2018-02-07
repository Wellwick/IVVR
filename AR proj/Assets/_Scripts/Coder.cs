using UnityEngine;
using UnityEditor;
using System;
public class Coder{

    private byte[] buff;
    private byte count;
    private int size;
    public Coder(int size){
        buff = new byte[size];
        count = 0;
        this.size = size;
    }

    public Coder(byte[] array) {
        buff = array;
        count = buff[0];
        size = array.Length;
    }

    public byte[] getArray() {
        buff[0] = count;
        return buff;
    }

    public byte getCount(){
        return count;
    }

    public bool isFull() {
        return ((((count+1)*49)+1)>size);
    }

    public void addSerial(byte type, int id, int assetId, Transform transform){
        if (isFull()) {
            Debug.LogError("Coder array is already full, can't add type " + type + " object id " + id);
            return;
        }
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

    private void writeIn(int value, int pos) {
        byte[] writeIn = BitConverter.GetBytes(value);
        for (int i = 0; i < writeIn.Length; i++) {
            buff[i+pos] = writeIn[i];
        }
    }

    private void writeIn(float value, int pos) {
        byte[] writeIn = BitConverter.GetBytes(value);
        for (int i = 0; i < writeIn.Length; i++) {
            buff[i+pos] = writeIn[i];
        }
    }

    public int readOutInt(int pos) {
        return BitConverter.ToInt32(buff, pos);
    }

    public float readOutFloat(int pos) {
        return BitConverter.ToSingle(buff,pos);
    }

    public byte GetType(int index) {
        if(illegalVal(index)){
            return 255;
        }
        //move the index to correct position
        index = 1 + (index*49);

        return buff[index];
    }

    public int GetID(int index) {
        if(illegalVal(index)){
            return -2;
        }
        //move the index to correct position
        index = 1 + (index*49);

        return readOutInt(index+1);
    }

    public int GetAssetID(int index) {
        if(illegalVal(index)){
            return -2;
        }
        //move the index to correct position
        index = 1 + (index*49);

        return readOutInt(index+5);
    }

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

    public Quaternion GetRotation(int index) {
        index = 1 + (index*49);
        float rotX = readOutFloat(index+21);
        float rotY = readOutFloat(index+25);
        float rotZ = readOutFloat(index+29);
        float rotW = readOutFloat(index+33);
        return new Quaternion(rotX, rotY, rotZ, rotW);

    }

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

    private bool illegalVal(int index) {
        if (index > buff[0]) {
            Debug.LogError("Coded message count does not reach value " + index);
            return true;
        }
        return false;
    }

}
