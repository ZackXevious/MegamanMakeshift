using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class victoryscreenscript : MonoBehaviour
{

    public StageControllerScript scScript;
    public Image[] secretIcons;
    public GameObject secretContainer;

    public void OnEnable() {
        scScript = GameObject.FindObjectOfType<StageControllerScript>();
        
        if (GameController.instance.stageNumber>0&&GameController.instance.stageNumber<5) {
            secretContainer.SetActive(true);
            for (int x = 0; x<3;x++) {
                if (scScript.secrets[x]) {
                    secretIcons[x].sprite = GameController.instance.SecretIcons[1];
                } else {
                    secretIcons[x].sprite = GameController.instance.SecretIcons[0];
                }
            }
        } else {
            secretContainer.SetActive(false);
        }
    }
    public void LoadPlayerMenu() {
        GameController.instance.setStageToGoTo(-1);
        GameController.instance.goToNextScene();
    }
}
