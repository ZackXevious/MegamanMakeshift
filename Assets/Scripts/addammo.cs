using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addammo : MonoBehaviour
{
    public int weaponNumber;
    public int AddAmmo;
    public GameObject deathspawn;
    public void FixedUpdate() {
        
    }
    private void OnTriggerEnter(Collider other) {
        this.doTheThing(other);
    }
    private void OnTriggerStay(Collider other) {
        this.doTheThing(other);
    }
    public void doTheThing(Collider other) {
        if (other.CompareTag("Player")) {
            if (GameObject.FindObjectOfType<StageControllerScript>().getWeapon(weaponNumber).getCurrAmmo() < (GameObject.FindObjectOfType<StageControllerScript>().getWeapon(weaponNumber).getMaxAmmo())) {
                GameObject.FindObjectOfType<StageControllerScript>().addWeaponAmmo(weaponNumber, AddAmmo);
                //Instantiate(deathspawn,this.transform.position,this.transform.rotation);
                Destroy(this.gameObject);
            } else {
                float currDistance = Vector3.Distance(this.transform.position, other.transform.position);
                this.GetComponent<Rigidbody>().AddForce(Vector3.MoveTowards(this.transform.position, other.transform.position, -1) * 25);
                //this.GetComponent<AudioSource>().Play();
            }
        }
    }
}
