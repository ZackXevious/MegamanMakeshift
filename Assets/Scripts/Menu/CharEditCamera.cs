using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharEditCamera : MonoBehaviour {

    public GameObject[] locations;
    public int speed=1;
    public int CurrentTarget;
    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
        CurrentTarget = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(this.transform.position,locations[CurrentTarget].transform.position)>.01) {
            this.transform.position = Vector3.Lerp(this.transform.position, locations[CurrentTarget].transform.position, Time.deltaTime*speed);
        } else {
            this.transform.position = locations[CurrentTarget].transform.position;
        }
        
    }
    public void setCurrentTarget(int index) {
        if (index < locations.Length) {
            CurrentTarget = index;
        } else {
            CurrentTarget = 0;
        }
    }
}
