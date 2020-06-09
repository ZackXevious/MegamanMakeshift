using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPanelScript : MonoBehaviour
{
    public GameObject BossCharacter;
    public Image[] BossCharacterHealthBar;
    float value;
    // Start is called before the first frame update
    void Start() {
        
        if (GameObject.FindObjectOfType<BossScript>() == null) {
            this.gameObject.SetActive(false);
        } else {
            BossCharacter = GameObject.FindObjectOfType<BossScript>().gameObject;
            value = BossCharacter.GetComponent<BasicEnemyScript>().health/20;
        }
        

    }

    // Update is called once per frame
    void Update() {
        if (GameObject.FindObjectOfType<BossScript>()!=null) {
            for (int x = 0; x < 20; x++) {
                if (BossCharacter.GetComponent<BasicEnemyScript>().health > value * x) {
                    BossCharacterHealthBar[x].gameObject.SetActive(true);
                } else {
                    BossCharacterHealthBar[x].gameObject.SetActive(false);
                }
            }
        }
        
    }
}
