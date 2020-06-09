using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPanel : MonoBehaviour
{
    public Text messageTitle;
    public Text messageText;
    public GameObject CycleButtons;
    public int currentMessage;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindObjectOfType<LoadingScreenScript>()!=null) {
            CycleButtons.SetActive(false);
        } else {
            CycleButtons.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cycleUp() {
        if (GameController.instance.playerData.CutscenesUnlocked[(currentMessage + 1) % 8]) {
            currentMessage = (currentMessage + 1) % 8;
            DisplayMessage();
        } else {
            currentMessage = (currentMessage + 1) % 8;
            cycleUp();
        }
    }
    public void cycleDown() {
        if (GameController.instance.playerData.CutscenesUnlocked[(currentMessage + 7) % 8]) {
            currentMessage = (currentMessage + 7) % 8;
            DisplayMessage();
        } else {
            currentMessage = (currentMessage + 7) % 8;
            cycleDown();
        }
    }
    public void setMessageNumber(int value) {
        this.currentMessage = value;
    }
    public void DisplayMessage() {
        GameController.instance.getMessageTitle(currentMessage);
    }
    public void CloseMessage() {
        if (GameObject.FindObjectOfType<LoadingScreenScript>()!=null) {
            GameObject.FindObjectOfType<LoadingScreenScript>().begin();
        }
        Destroy(this.gameObject);
    }
}
