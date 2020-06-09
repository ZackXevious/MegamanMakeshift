using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GameObject StrafeShotSpawn;
    public GameObject DefaultShotSpawn;
    public GameObject leftLegTarget;
    public GameObject rightLegTarget;
    public Animator anim;
    public GameObject CharRig;

    public float JumpAimStrenth;
    public float GunAimStrength;
    public bool GunAiming;
    
    // Start is called before the first frame update
    void Start()
    {
        CharRig.GetComponent<Animator>();
        StrafeShotSpawn = GameObject.FindGameObjectWithTag("StrafeTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGunWeight(float value) {
        GunAimStrength = value;
    }
    public bool getGunAiming() {
        return this.GunAiming;
    }
    void OnAnimatorIK() {
        if (StrafeShotSpawn!=null) {
            anim.SetIKPosition(AvatarIKGoal.RightHand, StrafeShotSpawn.transform.position);
            anim.SetLookAtPosition(StrafeShotSpawn.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, GunAimStrength);
            anim.SetLookAtWeight(1.0f, 0.5f, 1.0f, 0.0f, 0.75f);
            if (GunAimStrength >= 1) {
                GunAiming = true;
            } else {
                GunAiming = false;
            }
        }
    }
}
