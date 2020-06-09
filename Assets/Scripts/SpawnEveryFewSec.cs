using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEveryFewSec : MonoBehaviour {
	public float Delay=0;
	public float Sec=3;
	float temp;
	public string ObjectType;
	public GameObject whatToSpawn;

	// Use this for initialization
	void Start () {
		temp = Delay;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (temp > 0) {
			temp -= Time.deltaTime;
		} else {
			Instantiate (whatToSpawn,new Vector3(transform.position.x,transform.position.y+3,transform.position.z),transform.rotation);
			temp = Sec;
		}
	}
	void OnTriggerStay(Collider other){
		if (other.CompareTag (ObjectType)) {
			temp = Sec;
		}
	}
		
}
