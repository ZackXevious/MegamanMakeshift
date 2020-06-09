using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWeapon : MonoBehaviour
{
    public int WeaponToUnlock;
    public GameObject inactiveSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (GameObject.FindObjectOfType<StageControllerScript>().unlockWeapon(WeaponToUnlock)==true) {
                if (inactiveSpawner!=null) {
                    Instantiate(inactiveSpawner, this.transform.position,this.transform.rotation);
                }
                Destroy(this.gameObject);
            } else {

            }
        }
    }
}
