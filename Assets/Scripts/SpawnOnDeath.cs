using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour {

	public GameObject WhatToSpawn;
	// Use this for initialization
	
	// Update is called once per frame
	void OnDestroy(){
		//Debug.Log ("Spawning object "+WhatToSpawn.name);
		Instantiate (WhatToSpawn, this.transform.position,this.transform.rotation);
	}
}
