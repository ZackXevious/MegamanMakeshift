using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button loadButton;
    public GameObject ConfirmationWindow;
    public GameObject creditsScreen;
    public GameObject creditsSpawn;
    // Start is called before the first frame update
    void Start()
    {
        ConfirmationWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.playerData == null) {
            loadButton.interactable = false;
        }
    }
    public void showCredits() {

        Instantiate(creditsScreen, creditsSpawn.transform);
    }
    public void hideCredits() {
        creditsScreen.SetActive(false);
    }
    public void newGame() {
        GameController.instance.playerData = new PlayerStats();
        GameController.instance.setStageToGoTo(0);
        GameController.instance.goToNextScene();

    }
    public void LoadGame() {
        GameController.instance.setStageToGoTo(-1);
        GameController.instance.goToNextScene();
    }
    public void tryNewGame() {
        if (GameController.instance.playerData.stagesCompleted[0]) {
            ConfirmationWindow.SetActive(true);

        } else {
            newGame();
        }
    }
    public void CancelNewGame() {
        ConfirmationWindow.SetActive(false);
    }
}
