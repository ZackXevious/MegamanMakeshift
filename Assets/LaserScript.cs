using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float damage;
    public GameObject explosion;
    void Start()
    {
        RaycastHit hit;
        this.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
        Ray ray = new Ray(this.transform.position,this.transform.forward);
        if (Physics.Raycast(ray, out hit)) {
            this.GetComponent<LineRenderer>().SetPosition(1, hit.point);
            if (hit.transform.gameObject.GetComponent<BasicEnemyScript>()!=null) {
                hit.transform.gameObject.GetComponent<BasicEnemyScript>().DamageEnemy(damage);
            } else if (hit.transform.gameObject.GetComponent<Crate>() != null) {
                hit.transform.gameObject.GetComponent<Crate>().damageCrate(damage);
            }
            if (explosion!=null) {
                Instantiate(explosion, hit.point, this.transform.rotation);
            }
        } else {
            this.GetComponent<LineRenderer>().SetPosition(1, this.transform.position+transform.forward*50);
        }
    }
}
