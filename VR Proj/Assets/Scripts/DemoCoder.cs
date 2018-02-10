using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
public class DemoCoder : Coder {
    // Acts the same way as coder for the most part, apart from a few differences with prefabID and special
    // types of messages
    public DemoCoder(int size) : base(size) { }
    public DemoCoder(byte[] array) : base(array) { }

    //adds an update on an ARs position and what type of shooting it is doing
    public void addARUpdate(int id, int shootEnum, Transform transform) {
        byte type = (byte)NetworkManager.MessageIdentity.Type.ARUpdate;
        //replace the assetId with the shoot enumeration
        addSerial(type, id, shootEnum, transform);
    }

    //updates on the enemy health
    public void addEnemyUpdate(int id, int health, Transform transform) {
        byte type = (byte)NetworkManager.MessageIdentity.Type.EnemyUpdate;
        //replace assetId again with current health
        addSerial(type, id, health, transform);
    }

    //updates the VR on how much damage has been to an enemy by a given AR player since the last reliable
    //update
    public void addEnemyDamage(int id, int damage) {
        byte type = (byte)NetworkManager.MessageIdentity.Type.DamageEnemy;
        //replace assetId with how much damage has been done
        addSerial(type, id, damage, null); //doesn't need a transform
    }

    //updates the VR on how much healing has been done to the player locally on AR
    public void addPlayerHeal(int heal) {
        byte type = (byte)NetworkManager.MessageIdentity.Type.HealPlayer;
        //replace assetId with how much healing has be done
        addSerial(type, -1, heal, null); //doesn't need a transform
    }

    public void addPortal(bool[] runes) {
        byte type = (byte)NetworkManager.MessageIdentity.Type.PortalUpdate;
        int value = 0;
        for (int i = 0; i<runes.Length; i++) {
            if (runes[i]) value += 1 << i;
        }
        // Place the serialization of the current portal state into the assetID
        addSerial(type, -1, value, null);
    }

    public int GetShootEnum(int index) {
        return GetAssetID(index);
    }

    //needs to be compared with the local value, with the minimum taken
    public int GetEnemyHealth(int index) {
        return GetAssetID(index);
    }

    public int GetEnemyDamage(int index) {
        return GetAssetID(index);
    }

    public int GetPlayerHeal(int index) {
        return GetAssetID(index);
    }

    // Deserializes runes out of an int and into a boolean array of given size
    public bool[] GetPortalRunes(int index, int size) {
        int value = GetAssetID(index);
        bool[] runes = new bool[size];
        if (value < 0) {
            //we got a real problem!
            Debug.LogError("Got an impossible value for the portal serialization");
            //just set everything to false
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
        return runes;
    }

}