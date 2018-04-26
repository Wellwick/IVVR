using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
public class ExampleCoder : Coder {
    // An extension of Coder which can be adapted for project dependent requirements
    public ExampleCoder(int size) : base(size) { }
    public ExampleCoder(byte[] array) : base(array) { }

    /*
     * There are many ways in which the base Coder functionality can be extended
     * dependent on the requirements of your project.
     *
     * If you are not making use AssetId's or ids, this provides 64 bits of available
     * data. Equally, the Transform can be modified to store data as needed.
     *
     * If client side prediction is not needed, the Velocity of GameObjects may well
     * be redundant to your project, providing 96 bits of available data.
     *
     * If drastic changes are required, the type elements can be used to act as header
     * data to have variable sized items in the base Coder, however this may require 
     * modification of the base Coder class.
     * 
     * This makes use of examples found in the DemoCoder found in VR Proj and AR Proj
     */

    // Method to add a hypothetical Enemy's position and health, replacing the AssetID value
    public void addEnemyUpdate(int id, int health, Transform transform) {
        byte type = (byte)NetworkManager.MessageIdentity.Type.EnemyUpdate;
        //replace assetId again with current health
        addSerial(type, id, health, transform);
    }

    // Method to communicate a small array of booleans through replacement of ID
    // and AssetID values
    public void addPortal(bool[] runes, Transform transform) {
        byte type = (byte)NetworkManager.MessageIdentity.Type.PortalUpdate;
        // Need to keep track of how large the value becomes by bitwise shifting
        int value = 0;
        int count = 0;
        for (int i = 0; i<runes.Length; i++) {
            if (runes[i]) {
                // increment by a power of two to represent an active rune
                value += 1 << i;
                count++;
            }
        }
        // Place the serialization of the current portal state into the AssetID
        // value could be used on the other end to step downwards in bitwise shifts
        // Alternative count could be transferred
        addSerial(type, runes.Length, value, transform);
    }

    // Method to get a hypothetical Enemy's health, symmetric to addEnemyUpdate
    public int GetEnemyHealth(int index) {
        return GetAssetID(index);
    }

    // Deserializes runes out of an int and into a boolean array of given size
    // Makes the assumption that the size is known on the receiving end, however 
    // the value variable can be used if this is excluded
    public bool[] GetPortalRunes(int index, int size) {
        int value = GetAssetID(index);
        bool[] runes = new bool[size];
        if (value < 0) {
            // This represents a real problem!
            Debug.LogError("Got an impossible value for the portal serialization");
            // As a base case, set everything to false
            for (int i=0; i<runes.Length; i++) {
                runes[i] = false;
            }
        } else {
            // Step through the integer and bitwise check
            for (int i=0; i<runes.Length; i++) {
                if ((value & (1 << i)) != 0) runes[i] = true;
                else runes[i] = false;
            }
        }
        // Return the boolean array which was stored in the id
        return runes;
    }

}
