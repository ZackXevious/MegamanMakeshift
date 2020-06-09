using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationControls : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject NotificationSpawn;
    public GameObject NotificationPopup;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.instance.unlockedText.Count > 0) {
            Instantiate(NotificationPopup, NotificationSpawn.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.unlockedText.Count > 0) {
            this.MenuPanel.SetActive(false);
        } else {
            this.MenuPanel.SetActive(true);
        }
    }
    
}
