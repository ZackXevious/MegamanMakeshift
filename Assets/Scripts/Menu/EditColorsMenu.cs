using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditColorsMenu : MonoBehaviour{
    public CharacterBuilder cbScript;
    // Start is called before the first frame update
    void Start(){
        cbScript=GameObject.FindObjectOfType<CharacterBuilder>();
    }

    // Update is called once per frame
    public void setPrimaryColor(int value) {
        cbScript.setPrimary(value);
    }
    public void setSecondaryColor(int value) {
        cbScript.setSecondary(value);
    }
}
