using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperJoeAnimator : MonoBehaviour
{
    Animator anim;
    public Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setTarget(Transform tTransform) {
        this.targetTransform = tTransform;
    }
    public void setMoveSpeed(float value) {
        anim.SetFloat("Movespeed",value);
    }
    private void OnAnimatorIK(int layerIndex) {
        if (targetTransform!=null) {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, targetTransform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetLookAtPosition(targetTransform.position);
            anim.SetLookAtWeight(1, 1, 1);
        } else {
            anim.SetIKPosition(AvatarIKGoal.LeftHand, this.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            anim.SetLookAtPosition(this.transform.position);
            anim.SetLookAtWeight(0, 0, 0);
        }
        
    }
}
