using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicMenuScript : MonoBehaviour
{
    public GameObject[] MenuOptions;
    public GameObject spawnpoint;
    public GameObject optionsSpawn;
    public GameObject optionsMenu;
    public EventSystem eventObject;
    // Start is called before the first frame update
    void Start()
    {
        spawnpoint = GameObject.FindGameObjectWithTag("MenuSpawn");
        if (optionsSpawn==null) {
            optionsSpawn = GameObject.FindGameObjectWithTag("OptionsSpawn");
        }
        
        eventObject = GameObject.FindObjectOfType<EventSystem>();
    }

    public void selectMenuOption(int index) {
        Instantiate(MenuOptions[index], spawnpoint.transform);
        Destroy(this.gameObject);
    }
    public void LoadOptionsMenu() {
        GameObject optionspanel=Instantiate(optionsMenu, optionsSpawn.transform);
        optionspanel.GetComponent<OptionsScript>().setPreviousMenu(this.gameObject);
        this.gameObject.SetActive(false);
    }
    public void playSelectSound() {
        GameObject.FindObjectOfType<menusounds>().playSelectSound();
    }
    public void playConfirmSound() {
        GameObject.FindObjectOfType<menusounds>().playConfirmSound();
    }
    public void playBackSound() {
        GameObject.FindObjectOfType<menusounds>().playBackSound();
    }
    public void SaveGame() {
        GameController.instance.SaveGame();
    }
}
