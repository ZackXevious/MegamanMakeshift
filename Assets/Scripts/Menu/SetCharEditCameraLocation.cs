using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharEditCameraLocation : MonoBehaviour{
    CharEditCamera cecScript;
    public int location;
    // Start is called before the first frame update
    private void Start() {
        cecScript = GameObject.FindObjectOfType<CharEditCamera>();
    }
    void Update(){
        
        cecScript.setCurrentTarget(location);
    }

}
