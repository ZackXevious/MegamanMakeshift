using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject StageInfoPanel;
    
    public Text StageName;
    public Text StageDescriptionText;
    public Text CurrentGoalText;
    public Image[] secrets;
    public GameObject secretContainer;
    

    StageControllerScript scScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable() {
        scScript = GameObject.FindObjectOfType<StageControllerScript>();
        if (scScript != null) {
            StageInfoPanel.SetActive(true);
            StageName.text = GameController.instance.getStageName(GameController.instance.stageNumber);
            StageDescriptionText.text = "" + GameController.instance.getStageDescription(GameController.instance.stageNumber);
            if (GameController.instance.StageType[GameController.instance.stageNumber]==0) {
                CurrentGoalText.text = "Get to the end of the stage!";
            }else if (GameController.instance.StageType[GameController.instance.stageNumber] == 1) {
                CurrentGoalText.text = "Destroy the Generators! "+scScript.currentGoalTargetsLeft+" Left!";
            } else {
                CurrentGoalText.text = "Defeat Prototype V4!";
            }
            if (GameController.instance.stageNumber>0 && GameController.instance.stageNumber < 5) {
                for (int x=0; x<3; x++) {
                    if (scScript.secrets[x].activeSelf) {
                        this.secrets[x].sprite = GameController.instance.SecretIcons[0];
                    } else {
                        this.secrets[x].sprite = GameController.instance.SecretIcons[1];
                    }
                }
            } else {
                this.secretContainer.SetActive(false);
            }
            
        } else {
            StageInfoPanel.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
