using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : MonoBehaviour
{
    public Text notificationMessage;
    public Text ButtonMessage;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.instance.unlockedText.Count<=0) {
            Destroy(this.gameObject);
        }else if(GameController.instance.unlockedText.Count <= 1) {
            this.ButtonMessage.text = ("Continue");
        } else {
            this.ButtonMessage.text = "Next";
        }
        string value = (string)GameController.instance.unlockedText[GameController.instance.unlockedText.Count - 1];
        this.notificationMessage.text = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void next() {
        GameController.instance.unlockedText.RemoveAt(GameController.instance.unlockedText.Count - 1);
        if (GameController.instance.unlockedText.Count <= 0) {
            Destroy(this.gameObject);
        } else if (GameController.instance.unlockedText.Count <= 1) {
            this.ButtonMessage.text = ("Continue");
        } else {
            this.ButtonMessage.text = "Next";
        }
        string value = (string)GameController.instance.unlockedText[GameController.instance.unlockedText.Count - 1];
        this.notificationMessage.text = value;
    }
}
