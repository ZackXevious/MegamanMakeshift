using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditLegsMenu : MonoBehaviour
{
    public GameController gcScript;
    public CharacterBuilder cbScript;


    public Dropdown ThighSelector;
    public Dropdown CalfSelector;
    public Dropdown FootSelector;
    // Start is called before the first frame update
    void Start()
    {
        gcScript = GameObject.FindObjectOfType<GameController>();
        cbScript = GameObject.FindObjectOfType<CharacterBuilder>();

        //Make the options blank
        ThighSelector.ClearOptions();
        CalfSelector.ClearOptions();
        FootSelector.ClearOptions();

        //Generate the new values for the options
        List<string> Thigh_DropOptions = new List<string>();
        for (int x = 0; x < cbScript.getCurrentCharacterLoader().getNumThighs(); x++) {
            Thigh_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfThigh(x));
        }
        ThighSelector.AddOptions(Thigh_DropOptions);
        List<string> Calf_DropOptions = new List<string>();
        for (int x = 0; x < cbScript.getCurrentCharacterLoader().getNumLegs(); x++) {
            Calf_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfCalf(x));
        }
        CalfSelector.AddOptions(Calf_DropOptions);
        List<string> Foot_DropOptions = new List<string>();
        for (int x = 0; x < cbScript.getCurrentCharacterLoader().getNumFeet(); x++) {
            Foot_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfFoot(x));
        }
        FootSelector.AddOptions(Foot_DropOptions);

        //Add values back to dropdown
        ThighSelector.value = gcScript.getThighModel();
        CalfSelector.value = gcScript.getLegModel();
        FootSelector.value = gcScript.getFootModel();
    }
    public void setThighs(int index) {
        cbScript.setThigh(index);
    }
    public void setCalves(int index) {
        cbScript.setCalf(index);
    }
    public void setFeet(int index) {
        cbScript.setFoot(index);
    }
}
