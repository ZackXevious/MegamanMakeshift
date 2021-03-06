//Preprossessor Directives------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movement Variables---------------------------------------------------------------------------------------
[System.Serializable]
public class CCmovementVariables{

	//Movement variables
	public float maxMoveSpeed=20.0f;
	public float minMoveSpeed=3.0f;
	public float moveAccelTime=50.0f;
    public float midAirAcceleration;
    public float midAirboost;
	//Turning variables
	public float turnSpeed=20f;

	//Jumping variables
	public float JumpForce = 3f;
	public float maxJumpTime = .5f;//Amount of time you can hold down the jump button and keep going up.
    public float currJumpTime=0;
	public float gravity = 10f;

    //StrafeRelatedStuffs
    public float DashMaxTime;
    public float DashSpeed;
    public float DashTimer;
    

}

//Class Definition-----------------------------------------------------------------------------------------
public class PlayerMovement : MonoBehaviour {
    public GameObject PlayerCamera;
    private CharacterController cc;

    public float joyDeadZone;
    public CCmovementVariables moveVars;
    public float CurrMoveZed;
    public bool isJumping;
    public float movey;
    private Vector3 DesiredGlobalVelocity;
    Vector3 locVel;
    float currMove;

    //Animation related stuffs
    public GameObject characterRig;
    public Animator anim;
    public GameObject strafeObject;


    //Object Initialization------------------------------------------------------------------------------------
    void Start() {
        isJumping = false;
        //rb = this.GetComponent<Rigidbody>();
        PlayerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cc = this.GetComponent<CharacterController>();
        strafeObject = GameObject.FindGameObjectWithTag("Strafe");
        Debug.Log("Player has spawned successfully");
        anim = characterRig.GetComponent<Animator>();
        
        
    }
    void Update() {
    }

    //Logic Tick Update----------------------------------------------------------------------------------------
    void FixedUpdate() {
        //anim.SetFloat("Offset",anim.GetFloat("Offset")+Time.deltaTime*2);


        currMove = 0;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= this.joyDeadZone || Mathf.Abs(Input.GetAxis("Vertical")) >= this.joyDeadZone) {

            //Update the player's rotation------------------------------------------------------------------------------------------------------
            Vector3 v = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            Quaternion q = Quaternion.FromToRotation(this.transform.forward, v) * PlayerCamera.transform.rotation;
            Quaternion turnTo = this.transform.rotation * q;

            //Apply rotations
            Quaternion currTurn = Quaternion.Slerp(this.transform.rotation, turnTo, Time.deltaTime * moveVars.turnSpeed);
                                         //Keep Rotations only on the Y axis
            currTurn = Quaternion.Euler(new Vector3(0.0f, currTurn.eulerAngles.y, 0.0f));

            this.transform.rotation = currTurn;

            var analogInput = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
            currMove = moveVars.maxMoveSpeed * Mathf.Clamp(analogInput, 0, 1);
            anim.SetFloat("Movement speed", Mathf.Clamp(analogInput, 0, 1));

        } else {
            currMove = 0;
            anim.SetFloat("Movement speed", 0);
        }
        //On ground movement
        if (cc.isGrounded) {
            GameObject.FindObjectOfType<PlayerSounds>().onGround = true;
            anim.SetFloat("JumpChange", 0);
            movey = -2.5f;
            if (isJumping) {
                GameObject.FindObjectOfType<PlayerSounds>().playLandingSound();
            }
            isJumping = false;
            moveVars.currJumpTime = 0;
            anim.SetBool("InAir", false);

            //Actually Jump
            if (Input.GetButton("Jump") && (cc.isGrounded)) {
                movey = moveVars.JumpForce;

                isJumping = true;
                moveVars.currJumpTime = moveVars.maxJumpTime;
                GameObject.FindObjectOfType<PlayerSounds>().playJumpSound();
            }

            
            locVel.x = 0.0f;
            locVel.z = currMove;
            locVel.y = movey;
            cc.Move(transform.TransformDirection(locVel) * Time.deltaTime);
            
            DesiredGlobalVelocity = transform.TransformDirection(locVel*.75f);
            

        } else { //In-Air movement--------------------------------------------------------------------------------------------------
            anim.SetBool("InAir", true);
            anim.SetFloat("JumpChange", 1);
            anim.SetFloat("Movement speed", 0);
            GameObject.FindObjectOfType<PlayerSounds>().onGround=false;
            isJumping = true;
            //Changes in player movement
            

            Vector3 AirMove=transform.InverseTransformDirection(DesiredGlobalVelocity);

            locVel.x = 0.0f;
            locVel.z = currMove * moveVars.midAirAcceleration;
            locVel.y = 0.0f;
            Vector3 Total = AirMove + locVel;
            Total.z = Mathf.Clamp(
                Total.z,
                (-1.0f*Mathf.Abs(AirMove.z))-moveVars.midAirboost,
                Mathf.Abs(AirMove.z) + moveVars.midAirboost);
            Total.x = Mathf.Clamp(
                Total.x, 
                (-1.0f * Mathf.Abs(AirMove.x))- moveVars.midAirboost,
                Mathf.Abs(AirMove.x)+ moveVars.midAirboost);
            Total.y = movey;

            cc.Move(transform.TransformDirection(Total) * Time.deltaTime);
            DesiredGlobalVelocity = transform.TransformDirection(Total);
            //Debug.Log(DesiredGlobalVelocity.ToString());

            
            if (Input.GetButton("Jump") && moveVars.currJumpTime > 0) {
                moveVars.currJumpTime -= Time.deltaTime;
                movey = movey - moveVars.gravity * .25f * Time.deltaTime;
            } else if (Mathf.Abs(cc.velocity.y) < 3 ) {
                movey = movey - moveVars.gravity * 1 * Time.deltaTime;
            } else {
                movey = movey - moveVars.gravity * Time.deltaTime;
            }
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= this.joyDeadZone || Mathf.Abs(Input.GetAxis("Vertical")) >= this.joyDeadZone) {
            if (Input.GetAxis("Vertical") < -.1) {
                anim.SetFloat("MoveDirection", -1.0f);
                Quaternion turnto = Quaternion.Euler(0, PlayerCamera.transform.rotation.eulerAngles.y + (-45 * Input.GetAxis("Horizontal")), 0);
                strafeObject.transform.rotation = Quaternion.Slerp(strafeObject.transform.rotation, turnto, Time.deltaTime * moveVars.turnSpeed);
            } else {
                anim.SetFloat("MoveDirection", 1.0f);
                strafeObject.transform.rotation = Quaternion.Slerp(strafeObject.transform.rotation, this.transform.rotation, Time.deltaTime * moveVars.turnSpeed);
            }
        } else {
            strafeObject.transform.rotation = Quaternion.Slerp(strafeObject.transform.rotation, Quaternion.Euler(new Vector3(0.0f,PlayerCamera.transform.rotation.eulerAngles.y,0.0f)), Time.deltaTime * moveVars.turnSpeed);
        }
        

    }
    public void resetMovement() {
        Debug.Log("resetting player movement");
        this.locVel = Vector3.zero;
        currMove = 0;
        this.DesiredGlobalVelocity = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("EnemyAttack")&& collision.collider.gameObject.GetComponent<GunScript>()!=null) {
            Debug.Log("player was hit");

            GameObject.FindObjectOfType<StageControllerScript>().addPlayerHealth((int)collision.collider.gameObject.GetComponent<GunScript>().getDamage());
        }
    }
}