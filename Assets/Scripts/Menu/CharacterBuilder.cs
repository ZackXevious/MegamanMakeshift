using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterBuilder : MonoBehaviour {
    public GameObject gcObject;
    private GameController gcScript;
    public GameObject Character;
    public CharacterLoad CharLoader;


    //public Color[] ColorPallete = { Color.black, Color.red, new Color(1f,.5f,0f), Color.yellow, Color.green, Color.blue, Color.magenta, new Color(1f,0f,1f), Color.grey, Color.white};

	// Use this for initialization
	void Start () {
        gcObject = GameObject.FindGameObjectWithTag("GameController");
        gcScript = gcObject.GetComponent<GameController>();
        CharLoader = GameObject.FindObjectOfType<CharacterLoad>();

    }
    public CharacterLoad getCurrentCharacterLoader() {
        return CharLoader;
    }
    
    //Torso Stuff
    public void setHead(float value) {
        gcScript.setHeadModel((int)value % CharLoader.getNumHeads());
        CharLoader.SpawnHead();
    }
    public void setChest(float value) {
        gcScript.setChestModel((int)value % CharLoader.getNumChests());
        CharLoader.SpawnChest();
    }
    public void setWaist(float value) {
        gcScript.setWaistModel((int)value % CharLoader.getNumWaists());
        CharLoader.SpawnWaist();
    }
    //Arms Stuff
    public void setShoulders(float value) {
        gcScript.setShoulderModel((int)value % CharLoader.getNumShoulders());
        CharLoader.SpawnShoulders();
    }
    public void setForearms(float value) {
        gcScript.setArmModel((int)value % CharLoader.getNumArms());
        CharLoader.SpawnArms();
    }
    //Legs Stuff

    public void setThigh(float value) {
        gcScript.setThighModel((int)value % CharLoader.getNumThighs());
        CharLoader.SpawnThighs();
    }
    public void setCalf(float value) {
        gcScript.setLegModel((int)value % CharLoader.getNumLegs());
        CharLoader.SpawnLegs();
    }
    public void setFoot(float value) {
        gcScript.setFootModel((int)value % CharLoader.getNumFeet());
        CharLoader.SpawnFeet();
    }

    //Color stuffs
    public void setPrimary(int index) {
        gcScript.setPrimaryColor(index);
        CharLoader.refreshColors();
    }
    public void setSecondary(int index) {
        gcScript.setSecondaryColor(index);
        CharLoader.refreshColors();
    }
    public void setReflective(int index) {
        gcScript.setReflectiveColor(index);
        CharLoader.refreshColors();
    }
    public void setGlow(int index) {
        gcScript.setGlowColor(index);
        CharLoader.refreshColors();
    }
    public void setRubber(int index) {

    }

}
