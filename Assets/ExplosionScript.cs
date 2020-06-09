using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public string target;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        float currDistance = Vector3.Distance(this.transform.position,other.transform.position);
        if (other.gameObject.GetComponent<BasicEnemyScript>()!=null) {
            Debug.Log("Detected an enemy!");
            other.gameObject.GetComponent<BasicEnemyScript>().DamageEnemy(5);
        } else if (other.gameObject.GetComponent<Crate>() != null) {
            Debug.Log("Detected a crate!");
            other.gameObject.GetComponent<Crate>().damageCrate(damage);
        }
    }
}
