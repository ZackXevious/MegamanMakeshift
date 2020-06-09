using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject AimTarget;
    public bool leftTarget;
    public bool rightTarget;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    void FixedUpdate() {
        
    }
    void OnAnimatorIK() {
        if (AimTarget!=null) {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, AimTarget.transform.position);
            if (leftTarget) {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            } else {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            }
            anim.SetIKPosition(AvatarIKGoal.RightHand, AimTarget.transform.position);
            if (rightTarget) {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            } else {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            }
            
            anim.SetLookAtPosition(AimTarget.transform.position);
            anim.SetLookAtWeight(1, .5f, .5f);

        } else {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            anim.SetLookAtWeight(0,0,0);
        }
        
    }
    public void SetTarget(GameObject target) {
        AimTarget = target;
    }
}
