using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretScript : MonoBehaviour
{
    public GameObject deathSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GameObject.FindObjectOfType<HudScript>().DisplayHint("Secret Found!");
            this.gameObject.SetActive(false);

        }
    }
}
