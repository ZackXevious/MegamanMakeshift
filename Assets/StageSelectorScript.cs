using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectorScript : MonoBehaviour
{
    [Header("StageNumberInfo")]
    public int stageselected;

    [Header("StageImages")]
    public Sprite[] stageImages;
    public Image stageImageHolder;

    [Header("StageInfoText")]
    public Text StageNameText;
    public Text StageDescriptionText;
    public Image[] SecretsFound;
    public Text StageCompletedText;
    public Image StageCompletedIndicator;

    // Start is called before the first frame update
    void Start()
    {
        updateInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cycleUp() {
        if (GameController.instance.playerData.stagesUnlocked[(stageselected + 1) % 8]) {
            stageselected = (stageselected + 1) % 8;
            updateInfo();
        } else {
            stageselected = (stageselected + 1) % 8;
            cycleUp();
        }
        
    }
    public void cycleDown() {
        
        if (GameController.instance.playerData.stagesUnlocked[(stageselected + 7) % 8]) {
            stageselected = (stageselected + 7) % 8;
            updateInfo();
        } else {
            stageselected = (stageselected + 7) % 8;
            cycleDown();
        }
        
    }
    void updateInfo() {
        StageNameText.text = GameController.instance.getStageName(stageselected);
        StageDescriptionText.text = "" + GameController.instance.getStageDescription(stageselected);
        this.stageImageHolder.sprite = this.stageImages[stageselected];
        if (GameController.instance.playerData.stagesCompleted[stageselected]) {
            this.StageCompletedIndicator.color = new Color(0,1,0);
            this.StageCompletedText.text = "Completed";
            if (GameController.instance.playerData.stagesCompleted[stageselected] && stageselected > 0 && stageselected < 5) {
                Debug.Log("showing icons");
                for (int x = 0; x < 3; x++) {
                    
                    SecretsFound[x].color = new Color(1, 1, 1, 1);
                    if (GameController.instance.playerData.stageSecrets[stageselected - 1, x]) {
                        SecretsFound[x].sprite = GameController.instance.SecretIcons[1];
                    } else {
                        SecretsFound[x].sprite = GameController.instance.SecretIcons[0];
                    }
                }
            } else {
                Debug.Log("Hiding icons");
                
                for (int x = 0; x < 3; x++) {
                    SecretsFound[x].color = new Color(0, 0, 0, 0);
                }
            }

        } else {
            this.StageCompletedIndicator.color = new Color(1, 0, 0);
            this.StageCompletedText.text = "Incomplete";
        } 
        
    }
    public void warpToStage() {
        GameController.instance.stageNumber = this.stageselected;
        GameObject.FindObjectOfType<PlayerMenuScript>().goToScene();
    }
}
