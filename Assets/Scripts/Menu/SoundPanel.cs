using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class SoundPanel : MonoBehaviour {

    EventSystem controls;

    public Slider master;
    public Slider music;
    public Slider soundfx;

    public AudioMixer MasterMix;

    // Use this for initialization
    void Start () {
		
	}
    private void OnEnable() {
        controls = GameObject.FindObjectOfType<EventSystem>();
        Debug.Log("sound menu enabled");
        controls.SetSelectedGameObject(master.gameObject);
        float tempval;

        MasterMix.GetFloat("MasterVolume", out tempval);
        master.value = tempval;

        MasterMix.GetFloat("MusicVolume", out tempval);
        music.value = tempval;

        MasterMix.GetFloat("SFXVolume", out tempval);
        soundfx.value = tempval;
    }

    public void setMaster(float value) {
        MasterMix.SetFloat("MasterVolume",value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void setMusic(float value) {
        MasterMix.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void setSFX(float value) {
        MasterMix.SetFloat("SFXVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}
