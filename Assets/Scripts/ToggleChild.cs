using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleChild : MonoBehaviour
{
    public GameObject Child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (Child.activeSelf) {
                Child.SetActive(false);
            } else {
                Child.SetActive(true);
            }
        }
    }
}
