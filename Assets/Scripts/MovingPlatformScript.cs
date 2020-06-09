using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public bool pointingTowardsA;
    public float movespeed;
    public void Start() {
        if (pointingTowardsA) {
            this.transform.position = pointB.transform.position;
        } else {
            this.transform.position = pointA.transform.position;
        }
    }
    public void FixedUpdate() {
        if (pointingTowardsA) {
            if (Vector3.Distance(this.transform.position,pointA.transform.position)<.02) {
                this.transform.position = pointA.transform.position;
                pointingTowardsA = false;
            } else {
                this.transform.position = Vector3.MoveTowards(this.transform.position, pointA.transform.position, movespeed);
            }
        } else {
            if (Vector3.Distance(this.transform.position, pointB.transform.position) < .02) {
                this.transform.position = pointB.transform.position;
                pointingTowardsA = true;
            } else {
                this.transform.position = Vector3.MoveTowards(this.transform.position,pointB.transform.position,movespeed);
            }
        }

    }
    private void OnTriggerEnter(Collider other) {
        other.transform.SetParent(this.transform);
    }
    private void OnTriggerStay(Collider other) {
        other.transform.SetParent(this.transform);
    }
    private void OnTriggerExit(Collider other) {
        other.transform.SetParent(null);
    }
}
