using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthChange : MonoBehaviour
{
    StageControllerScript scScript;
    public GameObject deathspawn;
    public GameObject specificObjects;
    public int value;
    public bool isPermanent;
    // Start is called before the first frame update
    void Start()
    {
        scScript = GameObject.FindObjectOfType<StageControllerScript>();
    }

    // Update is called once per frame

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            if (value>0) {
                if (scScript.getPlayerHealth() < 20) {
                    scScript.addPlayerHealth(value);
                    Destroy(this.gameObject);
                } else {
                    this.GetComponent<AudioSource>().Play();
                }
            } else {
                scScript.addPlayerHealth(value);
                if (!isPermanent) {
                    Destroy(this.gameObject);
                }
                
            }
            
            
        }else if (other.CompareTag("Enemy")&&value<0) {
            Destroy(other.gameObject);
        }
    }
}
