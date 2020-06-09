using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject deathspawn;
    Rigidbody cc;
    public float ShotSpeed;
    public string WhoShotIt="Player";
    public string WhatTheBulletIs="PlayerAttack";
    public float damage;
    // Start is called before the first frame update
    void Start() {
        cc = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

    }
    private void FixedUpdate() {
        cc.velocity = transform.forward * ShotSpeed;
    }
    private void OnCollisionEnter(Collision collision) {
        this.DestroyAndDamage(collision.collider);
    }
    private void OnCollisionStay(Collision collision) {
        this.DestroyAndDamage(collision.collider);
    }
    private void DestroyAndDamage(Collider other) {
        if (!other.CompareTag(WhoShotIt) && !other.CompareTag(WhatTheBulletIs)&&!other.CompareTag("EnemyAttack")&& !other.CompareTag("PlayerAttack")) {
            if (deathspawn != null) {
                Instantiate(deathspawn, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
    public float getDamage() {
        return this.damage;
    }
}
