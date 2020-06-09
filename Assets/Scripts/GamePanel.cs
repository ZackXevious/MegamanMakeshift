using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public InputField XSensitivity;
    public InputField YSensitivity;
    public Toggle Inversion;
    // Start is called before the first frame update
    void Start()
    {
        XSensitivity.text = "" + GameController.instance.CameraSensativityX;
        YSensitivity.text = "" + GameController.instance.CameraSensativityY;
        Inversion.isOn= GameController.instance.CameraInversion;
    }

    public void setXSensativity(string value) {
        try {
            if (float.Parse(value) > 0) {
                GameController.instance.CameraSensativityX = float.Parse(value);
            } else {
                if (float.Parse(value) <= 0) {
                    GameController.instance.CameraSensativityX = 1;
                    XSensitivity.text = "" + 1;
                } else {
                    GameController.instance.CameraSensativityX = 15;
                    XSensitivity.text = "" + 15;
                }
            }
        } catch (FormatException) {
            Debug.Log("cannot parse!");
        }
        
        
    }
    public void setYSensativity(string value) {
        try {
            if (float.Parse(value) > 0 && float.Parse(value) <= 15) {
                GameController.instance.CameraSensativityY = float.Parse(value);
            } else {
                if (float.Parse(value) <= 0) {
                    GameController.instance.CameraSensativityY = 1;
                    YSensitivity.text = "" + 1;
                } else {
                    GameController.instance.CameraSensativityY = 15;
                    YSensitivity.text = "" + 15;
                }
                
            }
        } catch (FormatException) {
            Debug.Log("cannot parse!");
        }
    }
    public void setInversion(bool value) {
        GameController.instance.CameraInversion = value;
        if (value) {
            PlayerPrefs.SetInt("CamInversion",1);
        } else {
            PlayerPrefs.SetInt("CamInversion",0);
        }
    }
}
