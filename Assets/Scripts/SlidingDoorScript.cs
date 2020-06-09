using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorScript : MonoBehaviour
{
    public Animator DoorAnimator;
    bool open;
    public float openspeed=1;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        //DoorAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        if (open) {
            DoorAnimator.SetFloat("DoorCloseParam", Mathf.Clamp(DoorAnimator.GetFloat("DoorCloseParam") + openspeed*Time.deltaTime,0,1) );
        } else {
            DoorAnimator.SetFloat("DoorCloseParam", Mathf.Clamp(DoorAnimator.GetFloat("DoorCloseParam") - openspeed*Time.deltaTime, 0, 1));
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            open = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            open = false;
        }
    }

}
