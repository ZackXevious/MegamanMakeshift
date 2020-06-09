using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {
	public float Health=1;
	public GameObject hurtSpawn;
	public string adverseTo;
	public bool isFloating = false;
	public GameObject itemspawn;
	public float numDeath=1;
	public GameObject deathspawn;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Health <= 0) {
            Instantiate(deathspawn, this.transform.position, this.transform.rotation);
            if (itemspawn!=null) {
                GameObject goodie = Instantiate(itemspawn, this.transform.position, this.transform.rotation);
                goodie.GetComponent<goodieSpawn>().spawnRandoms(10);
            }
            
            Destroy(this.gameObject);
            
        }
		
	}
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log ("This is happening");
        if (collision.collider.CompareTag(adverseTo)) {

            Health -= 1;
            if (Health > 0) {
                Instantiate(hurtSpawn, this.transform.position, this.transform.rotation);
            }
        }
    }
    public void damageCrate(float value) {
        Health -= value;
    }
    
}
