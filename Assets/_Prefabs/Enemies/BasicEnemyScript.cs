using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    public bool Aggro;
    public float health;
    public GameObject deathspawn;
    public GameObject player;
    
    public float DistanceToForget;
    public float AggroDistance;
    public int GoodieOdds;
    public GameObject Goodies;

    public AudioClip hurtSound;
    public AudioClip AlertSound;

    private void FixedUpdate() {
        try {
            player = GameObject.FindGameObjectWithTag("Strafe");
        } catch {
            player = null;
        }
        
        if (player==null || Vector3.Distance(this.gameObject.transform.position, player.transform.position) > DistanceToForget) {//
            Aggro = false;
        } else if(player != null && Vector3.Distance(this.gameObject.transform.position, player.transform.position) < AggroDistance) {
            enableAggro();


        }
        if (health <= 0) {
            Instantiate(this.deathspawn, this.transform.position, this.transform.rotation);
            if (Goodies != null || GoodieOdds >0) {
                GameObject newgoodie = Instantiate(Goodies, this.transform.position, this.transform.rotation);
                newgoodie.GetComponent<goodieSpawn>().spawnRandoms(GoodieOdds);
            }
            
            Destroy(this.gameObject);
        }
    }
    public void DamageEnemy(float damage) {
        Debug.Log(this.gameObject.name+" was damaged!");
        this.health -= damage;
        enableAggro();
        if (this.GetComponent<AudioSource>()!=null) {
            this.GetComponent<AudioSource>().PlayOneShot(hurtSound, .75f);
        }
        
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("PlayerAttack")) {
            DamageEnemy(collision.collider.GetComponent<GunScript>().getDamage());
            enableAggro();
        }
        if (collision.collider.CompareTag("Player")) {
            enableAggro();
        }
    }
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") || other.CompareTag("PlayerAttack")) {
            enableAggro();

        }
    }
    public void enableAggro() {
        if (Aggro==false) {
            if (this.GetComponent<AudioSource>() != null) {
                this.GetComponent<AudioSource>().PlayOneShot(AlertSound, .75f);
            }   
        }
        Aggro = true;
    }
}
