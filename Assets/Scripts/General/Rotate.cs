using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {



	public float xRotate;
	public float yRotate;
	public float zRotate;
	public float xTranslate;
	public float yTranslate;
	public float zTranslate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Rotate (this.xRotate,this.yRotate,this.zRotate);
		this.transform.Translate (this.xTranslate,this.yTranslate,this.zTranslate);
	}
}
