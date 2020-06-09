using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndParent : MonoBehaviour {
    public GameObject spawnIn;

	// Use this for initialization
	void Start () {
        Instantiate(spawnIn,this.transform);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
