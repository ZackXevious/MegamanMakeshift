using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMetScript : MonoBehaviour
{
    public GameObject shotSpawn;
    public GameObject bullet;
    public BasicEnemyScript mainScript;

    public float shootTime;
    public float shootDuration;
    public float shootbetweenTime;
    public float shootbetweenDuration;
    public int numShots;
    public int totalShots;
    // Start is called before the first frame update
    void Start()
    {
        this.mainScript = this.GetComponent<BasicEnemyScript>();
    }

    public void FixedUpdate() {
        if (mainScript.Aggro) {
            this.transform.LookAt(mainScript.player.transform);
            if (shootTime <= 0) {
                Instantiate(this.bullet,this.shotSpawn.transform.position,this.shotSpawn.transform.rotation);
                shootTime = shootDuration;
            } else {
                shootTime -= Time.deltaTime;
            }
        }
    }
}
