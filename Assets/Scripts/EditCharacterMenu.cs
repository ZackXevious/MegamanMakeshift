using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditCharacterMenu : MonoBehaviour {
    [Header("Important stuff")]
    public GameController gcScript;
    public CharacterBuilder cbScript;


    [Header("ColorPanel")]
    public GameObject ColorSelectorPanel;
    //Primary Buttons
    public GameObject[] primaryButtons;
    //Secondary Buttons
    public GameObject[] secondaryButtons;
    //reflective Buttons
    public GameObject[] reflectiveButtons;
    //Glow Buttons
    public GameObject[] glowButtons;


    [Header("ArmorChunkPanel")]
    public GameObject ArmorPanel;

    // Start is called before the first frame update
    void Start() {
        cbScript = GameObject.FindObjectOfType<CharacterBuilder>();
        this.DisplayArmor();
        this.updateButtonColors();
    }

    // Update is called once per frame
    void Update() {

    }
    //Torso Stuff
    public void setHead(int value) {
        cbScript.setHead(value);
    }
    public void setChest(int value) {
        cbScript.setChest(value);
    }
    public void setWaist(int value) {
        cbScript.setWaist(value);
    }
    //Arms Stuff
    public void setShoulders(int value) {
        cbScript.setShoulders(value);
    }
    public void setForearms(int value) {
        cbScript.setForearms(value);
    }
    //Legs Stuff

    public void setThigh(int value) {
        cbScript.setThigh(value);
    }
    public void setCalf(int value) {
        cbScript.setCalf(value);
    }
    public void setFoot(int value) {
        cbScript.setFoot(value);
    }

    //Color stuffs
    public void setPrimary(int value) {
        cbScript.setPrimary(GameController.instance.getPrimaryColorIndex()+value);
        //GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(primaryButtons[1]);
        //GameObject.FindObjectOfType<EventSystem>().get
        this.updateButtonColors();
    }
    public void setSecondary(int value) {
        cbScript.setSecondary(GameController.instance.getSecondaryIndex()+value);
        //GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(secondaryButtons[1]);
        this.updateButtonColors();
    }
    public void setReflective(int value) {
        cbScript.setReflective(GameController.instance.getReflectiveIndex()+value);
        //GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(reflectiveButtons[1]);
        this.updateButtonColors();
    }
    public void setGlow(int value) {
        cbScript.setGlow(GameController.instance.getGlowIndex()+value);
        //GameObject.FindObjectOfType<EventSystem>().SetSelectedGameObject(glowButtons[1]);
        this.updateButtonColors();
    }

    public void updateButtonColors() {
        //Primary Button colors
        primaryButtons[0].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getPrimaryColorIndex() - 1);
        primaryButtons[1].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getPrimaryColorIndex());
        primaryButtons[2].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getPrimaryColorIndex() + 1);
        //Secondary Button colors
        secondaryButtons[0].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getSecondaryIndex() - 1);
        secondaryButtons[1].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getSecondaryIndex());
        secondaryButtons[2].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getSecondaryIndex() + 1);
        //Reflective Buttons colors
        reflectiveButtons[0].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getReflectiveIndex() - 1);
        reflectiveButtons[1].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getReflectiveIndex());
        reflectiveButtons[2].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getReflectiveIndex() + 1);
        //glow buttons colors
        glowButtons[0].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getGlowIndex() - 1);
        glowButtons[1].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getGlowIndex());
        glowButtons[2].GetComponent<Image>().color = GameController.instance.getPalletIndex(GameController.instance.getGlowIndex() + 1);
    }

    //Menu stuffs
    public void DisplayArmor() {
        this.ColorSelectorPanel.SetActive(false);
        this.ArmorPanel.SetActive(true);
    }
    public void DisplayColors() {
        this.ColorSelectorPanel.SetActive(true);
        this.ArmorPanel.SetActive(false);
    }
}
