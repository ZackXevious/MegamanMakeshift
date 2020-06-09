using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointTowardsPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        if (GameObject.FindGameObjectWithTag("Player")!=null) {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
        
    }
}
