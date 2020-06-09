using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardsObject : MonoBehaviour
{
    public GameObject target;
    public string targetDescriptor;
    public float movespeed;
    public bool destroyOnContact;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetDescriptor);
        if (target==null) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        this.transform.position = Vector3.MoveTowards(this.transform.position,target.transform.position, movespeed);
        if (Vector3.Distance(this.transform.position,target.transform.position)<.1&&destroyOnContact) {
            Destroy(this.gameObject);
        }
    }
}
