using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleScreenScript : MonoBehaviour {
    public GameObject startMenu;
    public EventSystem eventSystem;
    public GameObject firstInStart;
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown || Input.GetButton("Jump")) {
            startMenu.SetActive(true);
            eventSystem.SetSelectedGameObject(firstInStart);
            GameObject.FindObjectOfType<menusounds>().playConfirmSound();
            this.gameObject.SetActive(false);
        }
	}
}
