using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dropdown : MonoBehaviour {

    public Canvas infoCanvas;
    public void InfoToggle()
    {
        infoCanvas.enabled = !infoCanvas.isActiveAndEnabled;
    }


    List<string> actions = new List<string>() { "Select Action","Spawn", "Explode", "Fire", "Remove","Throw" };
    List<string> objects = new List<string>() { "Select Object", "Brick", "Wall", "Cube","Ball" };

    public Dropdown actionDropdown;
    public Text selectedAction;

    public Dropdown objectDropdown;
    public Text selectedObject;
    
    public void ActionDropdownIndexChange(int index)
    {
        selectedAction.text = actions[index];

        switch(actions[index]){
            case "Throw": objects = new List<string>() {"Select Object","Ball"}; break;
            case "Spawn": objects = new List<string>() { "Select Object", "Brick", "Wall", "Cube","Ball" };break;
            case "Fire": objects = new List<string>() { "Select Object", "Brick", "Wall", "Cube","Ball" };break;
            case "Remove": objects = new List<string>() { "Select Object", "Brick", "Wall", "Cube","Ball" };break;
        }
        objectDropdown.ClearOptions();
        objectDropdown.AddOptions(objects);
    }

    public void ObjectDropdownIndexChange(int index)
    {
        selectedObject.text = objects[index];
    }
    void PopulateList()
    {
        actionDropdown.AddOptions(actions);
        objectDropdown.AddOptions(objects);
    }

    public void DoAction()
    {
        
    }

    public void UIConnect()
    {

    }


    void Start () 
    {
        PopulateList();
        infoCanvas.enabled = false; 
    }



}
