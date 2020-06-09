using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour {
    EventSystem controls;

    StageControllerScript scScript;

    public GameObject previousMenu;

    public Button SoundButton;
    public Button GameButton;
    public Button VideoButton;

    public GameObject soundmenu;
    public GameObject gamesettingsmenu;
    public GameObject graphicsmenu;
    

    public GameObject firstInGameSettings;
    public GameObject firstInGraphics;

    // Use this for initialization
    private void OnEnable() {
        controls = GameObject.FindObjectOfType<EventSystem>();
        this.enableSoundMenu();
    }
    private void Start() {
        controls = GameObject.FindObjectOfType<EventSystem>();
        scScript = GameObject.FindObjectOfType<StageControllerScript>();
        this.enableSoundMenu();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void enableSoundMenu() {

        soundmenu.SetActive(true);
        graphicsmenu.SetActive(false);
        gamesettingsmenu.SetActive(false);

        //SoundButton.enabled = (false);
        SoundButton.interactable = false;
        GameButton.interactable = (true);
        VideoButton.interactable = (true);

    }
    public void enableGraphicsMenu() {

        
        controls.SetSelectedGameObject(firstInGraphics);

        soundmenu.SetActive(false);
        graphicsmenu.SetActive(true);
        gamesettingsmenu.SetActive(false);

        SoundButton.interactable = (true);
        GameButton.interactable = (true);
        VideoButton.interactable = (false);
        
    }
    public void enableGameSettingsMenu() {


        controls.SetSelectedGameObject(firstInGameSettings);

        soundmenu.SetActive(false);
        graphicsmenu.SetActive(false);
        gamesettingsmenu.SetActive(true);

        SoundButton.interactable = (true);
        GameButton.interactable = (false);
        VideoButton.interactable = (true);
    }
    public void setPreviousMenu(GameObject prevMenu) {
        this.previousMenu = prevMenu;
    }
    public void closeOptions() {
        previousMenu.SetActive(true);
        Destroy(this.gameObject);
    }
}
