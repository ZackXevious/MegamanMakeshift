using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWhenCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        GameObject.FindObjectOfType<PlayerSounds>().playFootSound();
        
    }
}
