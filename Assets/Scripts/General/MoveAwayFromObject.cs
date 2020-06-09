using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAwayFromObject : MonoBehaviour {

	public GameObject objectToRunAwayFrom;
	public string runAwayProp;
	public float minDistance;
	private float currDistance;
	void Start(){
		Debug.Log ("finding object");

	}
	void FixedUpdate(){
		objectToRunAwayFrom = GameObject.FindGameObjectWithTag ("Player");
		if (this.objectToRunAwayFrom != null) {
			currDistance = Vector3.Distance (this.transform.position, objectToRunAwayFrom.transform.position);
			if (currDistance < minDistance) {
				moveAwayfromObject ();
			}
		}
	}
	void moveAwayfromObject(){
		this.transform.position = Vector3.MoveTowards (this.transform.position,objectToRunAwayFrom.transform.position,(-20.0f/(currDistance/2))*Time.deltaTime);
	}
}