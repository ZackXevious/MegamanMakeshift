using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasMenu : MonoBehaviour
{
    public GameObject creditsWindow;
    public GameObject messagesWindow;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        this.spawn = GameObject.FindGameObjectWithTag("OptionsSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayCredits() {
        Instantiate(creditsWindow,spawn.transform);
    }
    public void DisplayMessages() {

    }
}
