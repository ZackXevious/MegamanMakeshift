using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerCameraScript : MonoBehaviour
{
    public Camera defaultCamera;
    public Camera FrontCamera;
    public Camera SideCamera;
    public Camera ControllableCamera;
    public StageControllerScript scScript;
    public GameObject playerCamRig;
    public GameObject RotationRig;

    public CharacterLoad charloader;
    // Start is called before the first frame update
    void Start()
    {
        defaultCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        scScript = GameObject.FindObjectOfType<StageControllerScript>();
        playerCamRig = GameObject.FindObjectOfType<CameraControls>().gameObject;
        charloader = GameObject.FindObjectOfType<CharacterLoad>();
        setDefaultCamera();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerCamRig.transform.position;
        this.transform.rotation = playerCamRig.transform.rotation;// Quaternion.Euler(0, playerCamRig.transform.rotation.eulerAngles.y, 0);
        //this.transform.rotation = playerCamRig.transform.rotation;
        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            setDefaultCamera();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            setFrontCamera();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            setSideCamera();
        }

        //Controllable camera toggles
        if (Input.GetKeyDown(KeyCode.Keypad7)) {
            setControllableCamera();
        }
        if (Input.GetKey(KeyCode.Keypad4)) {
            RotationRig.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.Keypad6)) {
            RotationRig.transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.Keypad5)) {
            this.resetControllableCamera();
        }

    }
    void setDefaultCamera() {
        defaultCamera.enabled = true;
        FrontCamera.enabled = false;
        SideCamera.enabled = false;
        ControllableCamera.enabled = false;
        scScript.displayHud = true;
    }
    void setFrontCamera() {
        defaultCamera.enabled = false;
        FrontCamera.enabled = true;
        SideCamera.enabled = false;
        ControllableCamera.enabled = false;
        scScript.displayHud = false;
    }
    void setSideCamera() {
        defaultCamera.enabled = false;
        FrontCamera.enabled = false;
        SideCamera.enabled = true;
        ControllableCamera.enabled = false;
        scScript.displayHud = false;
    }
    void setControllableCamera() {
        defaultCamera.enabled = false;
        FrontCamera.enabled = false;
        SideCamera.enabled = false;
        ControllableCamera.enabled = true;
        scScript.displayHud = false;
    }
    void resetControllableCamera() {
        RotationRig.transform.rotation = this.transform.rotation;
    }
}
