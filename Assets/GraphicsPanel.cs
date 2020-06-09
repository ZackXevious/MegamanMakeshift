using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsPanel : MonoBehaviour
{
    [Header("Effects Toggles")]
    public Toggle bloomToggle;
    public Toggle MotionBlurToggle;
    public Toggle DOFToggle;
    [Header("StandardGUIStuff")]
    public Dropdown ResultionDropDown;
    public Dropdown GraphicsDefaultsDropdown;
    public Toggle ShowFPSToggle;


    void Start()
    {
        ShowFPSToggle.isOn=GameController.instance.ShowFPS;
        bloomToggle.isOn = GameController.instance.BoolBloom;
        MotionBlurToggle.isOn = GameController.instance.BoolMotionBlur;
        DOFToggle.isOn = GameController.instance.BoolDepthofField;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowFPS(bool toggle) {
        GameController.instance.ShowFPS = toggle;
        if (toggle) {
            PlayerPrefs.SetInt("ShowFPS",1);
        } else {
            PlayerPrefs.SetInt("ShowFPS",0);
        }
    }
    public void ToggleBloom(bool toggle) {
        GameController.instance.BoolBloom = toggle;
        if (toggle) {
            PlayerPrefs.SetInt("Bloom", 1);
        } else {
            PlayerPrefs.SetInt("Bloom", 0);
        }
    }
    public void ToggleMotionBlur(bool toggle) {
        GameController.instance.BoolMotionBlur = toggle;
        if (toggle) {
            PlayerPrefs.SetInt("MotionBlur", 1);
        } else {
            PlayerPrefs.SetInt("MotionBlur", 0);
        }
    }
    public void ToggleDOF(bool toggle) {
        GameController.instance.BoolDepthofField = toggle;
        if (toggle) {
            PlayerPrefs.SetInt("DOF", 1);
        } else {
            PlayerPrefs.SetInt("DOF", 0);
        }
    }
}
