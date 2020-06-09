using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnCollison : MonoBehaviour {
	public string friendly="Player";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollision(Collision other){
		if (!other.gameObject.CompareTag (friendly)&&!other.gameObject.CompareTag ("Pickup")&&!other.gameObject.CompareTag ("Checkpoint")) {
			Destroy (this.gameObject);
		}


	}
	void OnTriggerEnter(Collider other){
		
		if (!other.gameObject.CompareTag (friendly)&&!other.gameObject.CompareTag ("Pickup")){//&&!other.gameObject.CompareTag ("Checkpoint")) {
			Destroy (this.gameObject);
		}
	}
}
