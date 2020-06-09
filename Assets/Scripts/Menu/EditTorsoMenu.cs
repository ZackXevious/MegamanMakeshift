using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditTorsoMenu : MonoBehaviour
{
    public GameController gcScript;
    public CharacterBuilder cbScript;
    public Dropdown HeadSelector;
    public Dropdown ChestSelector;
    public Dropdown WaistSelector;
    // Start is called before the first frame update
    void Start()
    {
        gcScript = GameObject.FindObjectOfType<GameController>();
        cbScript = GameObject.FindObjectOfType<CharacterBuilder>();

        //Make the options blank
        HeadSelector.ClearOptions();
        ChestSelector.ClearOptions();
        WaistSelector.ClearOptions();

        //Generate the new values for the options
        List<string> Head_DropOptions = new List<string>();
        for (int x = 0; x < cbScript.getCurrentCharacterLoader().getNumHeads(); x++) {
            Head_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfHead(x));
        }
        HeadSelector.AddOptions(Head_DropOptions);
        List<string> Chest_DropOptions = new List<string>();
        for (int x = 0; x < cbScript.getCurrentCharacterLoader().getNumChests(); x++) {
            Chest_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfChest(x));
        }
        ChestSelector.AddOptions(Chest_DropOptions);
        List<string> Waist_DropOptions = new List<string>();
        for (int x = 0; x < cbScript.getCurrentCharacterLoader().getNumWaists(); x++) {
            Waist_DropOptions.Add(cbScript.getCurrentCharacterLoader().getNameOfWaist(x));
        }
        WaistSelector.AddOptions(Waist_DropOptions);

        //Add values back to dropdown
        HeadSelector.value = gcScript.getHeadModel();
        ChestSelector.value = gcScript.getChestModel();
        WaistSelector.value = gcScript.getWaistModel();
    }
    public void setHead(int index) {
        cbScript.setHead(index);
    }
    public void setChest(int index) {
        cbScript.setChest(index);
    }
    public void setWaist(int index) {
        cbScript.setWaist(index);
    }
}
