using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {


    //Camera aiming stuffs
    public float upCameraLimit=90;
    public float downCameraLimit=-90;
    public float SensativityX = 10;
    public float SensativityY = 10;
    public float rotationX = 0;
    public float frictionmodifier;

    //Stuff related to how the camera sticks to the player
    public float vertOffset;
    public float CameraVertDrift;

    //GameObjects
    public GameObject player;
    public GameObject playerCamera;


    public GameObject AimLocation;
    public GameObject defaultAimLocation;


    // Use this for initialization
    void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate() {
        //have to add 90 because the default location of euler angles is 0

        //Debug.Log("Rotation X="+rotationX);
        //Raycast stuff
        RaycastHit hit;
        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        if (Physics.Raycast(ray, out hit)) {
            this.AimLocation.transform.position = hit.point;
            if (hit.transform.gameObject.CompareTag("Enemy")) {
                SensativityX = Vector2.MoveTowards(new Vector2(0,SensativityX),new Vector2(0, GameController.instance.CameraSensativityX * frictionmodifier), 2f).y;
                SensativityY = Vector2.MoveTowards(new Vector2(0, SensativityY), new Vector2(0, GameController.instance.CameraSensativityY * frictionmodifier), 2f).y;
            } else {
                SensativityX = GameController.instance.CameraSensativityX;
                SensativityY = GameController.instance.CameraSensativityY;
            }
        } else {
            this.AimLocation.transform.position = this.defaultAimLocation.transform.position;
            SensativityX = GameController.instance.CameraSensativityX;
            SensativityY = GameController.instance.CameraSensativityY;
        }


        
        this.SetCameraRigPosition();
        int inverted = 0;
        if (GameController.instance.CameraInversion) {
            inverted = -1;
        } else {
            inverted = 1;
        }
        this.transform.RotateAround(this.transform.position,Vector3.up,Input.GetAxis("Cam X")*SensativityX);
        float desiredXRot = -Input.GetAxis("Cam Y") * SensativityY * inverted;
        if (desiredXRot>0 && desiredXRot+rotationX>upCameraLimit) {
            desiredXRot = upCameraLimit - rotationX;

        } else if(desiredXRot < 0 && desiredXRot+rotationX < downCameraLimit) {
            desiredXRot = downCameraLimit-rotationX;
        }
        
        //Debug.Log(desiredXRot);
        this.transform.RotateAround(this.transform.position, playerCamera.transform.right, desiredXRot);
        if (this.transform.rotation.eulerAngles.x < 180) {
            rotationX = this.transform.rotation.eulerAngles.x;
        } else {
            rotationX = -360 + this.transform.rotation.eulerAngles.x;
        }
        //Debug.ClearDeveloperConsole();

        float rotYDifference = Mathf.Abs(this.transform.rotation.eulerAngles.y-player.transform.rotation.eulerAngles.y);

        
    }
    void SetCameraRigPosition() {
        this.transform.position = new Vector3(
            player.transform.position.x,
            Mathf.Lerp(this.transform.position.y, player.transform.position.y + vertOffset, Time.fixedDeltaTime * CameraVertDrift),
            player.transform.position.z);
    }
}
