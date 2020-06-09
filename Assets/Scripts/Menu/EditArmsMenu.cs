using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditArmsMenu : MonoBehaviour
{
    public GameController gcScript;
    public CharacterBuilder cbScript;


    public Dropdown ArmsSelector;
    public Dropdown ShouldersSelector;
    // Start is called before the first frame update
    void Start()
    {
        gcScript = GameObject.FindObjectOfType<GameController>();
        cbScript = GameObject.FindObjectOfType<CharacterBuilder>();

        //Make the options blank
        ArmsSelector.ClearOptions();
        ShouldersSelector.ClearOptions();

        //Generate the new values for the options
        List<string> Arm_DropOptions = new List<string>();
        for (int x=0; x< cbScript.getCurrentCharacterLoader().getNumArms(); x++) {
            Arm_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfArm(x));
        }
        ArmsSelector.AddOptions(Arm_DropOptions);
        List<string> Shoulder_DropOptions = new List<string>();
        for (int x = 0; x < cbScript.getCurrentCharacterLoader().getNumShoulders(); x++) {
            Shoulder_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfShoulder(x));
        }
        ShouldersSelector.AddOptions(Shoulder_DropOptions);

        //Set the default options to be what the GameController wants them to be
        ArmsSelector.value = gcScript.getArmModel();
        ShouldersSelector.value = gcScript.getShoulderModel();
    }

    public void setArms(int index) {
        cbScript.setForearms(index);
    }
    public void setShoulders(int index) {
        cbScript.setShoulders(index);
    }
}
