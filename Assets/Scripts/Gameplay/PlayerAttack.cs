using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAttack : MonoBehaviour {

    public GameObject gcObject;
    public GameController gcScript;
    public StageControllerScript scScript;
    public PlayerAnimator playerAnim;


    public GameObject attackspawn;
    public GameObject NormalAttackSpawn;
    public GameObject AimAttackSpawn;

	public GameObject ParticleObject;
    public GameObject[] gunmodel;
    public GameObject[] bullets;
    public AudioClip[] gunSounds;
    public GameObject armspawn;
    public GameObject currGunModel=null;

    public GameObject CharObject;
    public CharacterLoad CharLoader;
    //animation stuff
    public GameObject Playerrig;
    public Animator anim;


    public float GunAlertTimer;
    public float GunAlertMaxDelay;

    public float AnimSpeedModifier;
    public float AnimTime;

    public float shotDelay;
    public bool alreadyshot;

    public float switchDelay;
    public float maxSwitchDelay=.1f;

    private void Start() {
        anim = Playerrig.GetComponent<Animator>();
        gcScript = GameController.instance;
        scScript = GameObject.FindObjectOfType<StageControllerScript>();
        CharLoader = CharObject.GetComponent<CharacterLoad>();
        alreadyshot = false;
    }

    void FixedUpdate(){


        int currweapValue = scScript.getCurrentWeapon();
        //Weapon Cycle code
        if (Input.GetAxis("Scroll") > 0 && switchDelay<=0) {
            
            scrollWeaponUp(currweapValue);
            switchDelay = maxSwitchDelay;
        }else if (Input.GetAxis("Scroll") < 0 && switchDelay <= 0) {
            scrollWeaponDown(currweapValue);
            switchDelay = maxSwitchDelay;
        }
        if (switchDelay > 0) {
            switchDelay -= Time.deltaTime;
        }

        //Attacking stuff
        if (scScript.getWeapon(scScript.getCurrentWeapon()).getCurrAmmo()> 0 || scScript.getWeapon(scScript.getCurrentWeapon()).getMaxAmmo()<1) {
            WeaponClass currentWeapon = scScript.getWeapon(scScript.getCurrentWeapon());

            
            if (!(currentWeapon.getShotDelay()>0) && (Input.GetButtonDown("Attack")||alreadyshot)) {//Single Shot Weapons
                this.FireBullet();
                
                


            } else if(Input.GetButton("Attack")&& (currentWeapon.getShotDelay() > 0)&&shotDelay<=0) {//Rapid Fire Weapons
                shotDelay = currentWeapon.getShotDelay();
                this.FireBullet();
            }
            
        }
        if (shotDelay>0) {
            shotDelay -= Time.deltaTime;
        } else {
            shotDelay = 0;
        }


        //Animation stuff--------------------
        if (GunAlertTimer>0) {
            AnimTime = Mathf.Clamp(AnimTime + Time.deltaTime * (AnimSpeedModifier*3), 0, 1);
            GunAlertTimer = Mathf.Clamp(GunAlertTimer-Time.deltaTime,0,GunAlertMaxDelay);

        } else {
            AnimTime = Mathf.Clamp(AnimTime - Time.deltaTime * AnimSpeedModifier, 0, 1);
            Destroy(currGunModel);//remove the gun
            CharLoader.ShowArms();
        }
        playerAnim.SetGunWeight(AnimTime);
    }
    void swapWeaponModel() {
        if (GunAlertTimer > 0) {
            if (currGunModel != null) {
                Destroy(currGunModel);//remove the gun
            }
            currGunModel = Instantiate(gunmodel[scScript.getCurrentWeapon()], armspawn.transform);
        }
    }
    void FireBullet() {
        GunAlertTimer = GunAlertMaxDelay;
        CharLoader.HideArm(true);
        this.swapWeaponModel();
        if (playerAnim.getGunAiming()) {
            Instantiate(bullets[scScript.getCurrentWeapon()], attackspawn.transform.position, attackspawn.transform.rotation);
            this.GetComponent<AudioSource>().PlayOneShot(this.gunSounds[scScript.getCurrentWeapon()]);
            WeaponClass currentWeapon = scScript.getWeapon(scScript.getCurrentWeapon());
            currentWeapon.setCurrAmmo(scScript.getWeapon(scScript.getCurrentWeapon()).getCurrAmmo() - 1);
            alreadyshot = false;
        } else {
            alreadyshot = true;
        }
        
    }
    void scrollWeaponUp(int value) {
        scScript.setCurrentWeapon((scScript.getCurrentWeapon() + 1) % 5);
        if (gcScript.playerData.weaponsUnlocked[scScript.getCurrentWeapon()]!=true || (scScript.getWeapon(scScript.getCurrentWeapon()).currAmmo<1 && scScript.getWeapon(scScript.getCurrentWeapon()).getMaxAmmo() > 0)) {
            scrollWeaponUp(value);
        }
        swapWeaponModel();
        if (scScript.getCurrentWeapon()!=value) {
            GameObject.FindObjectOfType<PlayerSounds>().playSwapSound();
        }
        
    }
    void scrollWeaponDown(int value) {
        scScript.setCurrentWeapon((scScript.getCurrentWeapon() +4) % 5);
        if (gcScript.playerData.weaponsUnlocked[scScript.getCurrentWeapon()] != true || (scScript.getWeapon(scScript.getCurrentWeapon()).currAmmo < 1 && scScript.getWeapon(scScript.getCurrentWeapon()).getMaxAmmo() > 0)) {
            scrollWeaponDown(value);
        }
        swapWeaponModel();
        if (scScript.getCurrentWeapon() != value) {
            GameObject.FindObjectOfType<PlayerSounds>().playSwapSound();
        }
    }
}
