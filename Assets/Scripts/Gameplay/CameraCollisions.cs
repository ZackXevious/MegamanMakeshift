using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisions : MonoBehaviour {
	public GameObject nearest;
	public GameObject farthest;
	public GameObject Camrig;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*RaycastHit wallHit = new RaycastHit();
		if(Physics.Linecast(targetFollow, camMask, out wallHit, CamOcclusion)){
			//the smooth is increased so you detect geometry collisions faster.
			smooth = 10f;
			//the x and z coordinates are pushed away from the wall by hit.normal.
			//the y coordinate stays the same.
			this.transform = new Vector3(wallHit.point.x + wallHit.normal.x * 0.5f, camPosition.y, wallHit.point.z + wallHit.normal.z * 0.5f);
		}*/

		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		float disttoNearest = Vector3.Distance (this.transform.position, nearest.transform.position);
		float disttoFarthest = Vector3.Distance (this.transform.position, farthest.transform.position);
		Vector3 directionToCamera = farthest.transform.position-Camrig.transform.position;
		RaycastHit hit;
		Debug.DrawRay (Camrig.transform.position,directionToCamera,Color.red);

		if (Physics.Raycast (Camrig.transform.position,directionToCamera,out hit,10)) {
			
			Debug.Log ("camera collision");
			this.transform.position = hit.point;
		} else{ 
			this.transform.position = Vector3.Slerp (this.transform.position,farthest.transform.position,Time.deltaTime*10);

		}//if(!Physics.Raycast (transform.position, directionToCamera, disttoFarthest)){
	}

}
