using UnityEngine;
using UnityEditor;
using System;
public class DemoCoder : Coder {
    // Acts the same way as coder for the most part, apart from a few differences with prefabID and special
    // types of messages

    //adds an update on an ARs position and what type of shooting it is doing
    public void addARUpdate(int id, int shootEnum, Transform transform) {
        byte type = NetworkManager.MessageIndentity.Type.ARUpdate;
        //replace the assetId with the shoot enumeration
        addSerial(type, id, shootEnum, transform);
    }

    //updates on the enemy health
    public void addEnemyUpdate(int id, int health, Transform transform) {
        byte type = NetworkManager.MessageIndentity.Type.EnemyUpdate;
        //replace assetId again with current health
        addSerial(type, id, health, transform);
    }

    //updates the VR on how much damage has been to an enemy by a given AR player since the last reliable
    //update
    public void addEnemyDamge(int id, int damage) {
        byte type = NetworkManager.MessageIndentity.Type.DamageEnemy;
        //replace assetId with how much damage has been done
        addSerial(type, id, damage, null); //doesn't need a transform
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

}