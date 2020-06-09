using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSpawner : MonoBehaviour
{
    public string text;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GameObject.FindObjectOfType<HudScript>().DisplayHint(text);
        }
    }
}
