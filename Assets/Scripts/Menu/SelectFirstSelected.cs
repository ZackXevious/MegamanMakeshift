using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectFirstSelected : MonoBehaviour {
    public GameObject firstSelected;
    public EventSystem eventmanager;

	// Use this for initialization
	void onEnable() {
        eventmanager.SetSelectedGameObject(firstSelected);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
