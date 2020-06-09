using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetTurretScript : MonoBehaviour
{

    [Header("Standard Enemy Stuff")]
    public BasicEnemyScript mainScript;

    [Header("Turret stuff")]
    public GameObject TurretShotSpawn;
    public GameObject Bullet;
    public GameObject TurretMain;
    public GameObject target;

    [Header("AI related stuff")]
    public bool targetlocked;
    public int numShots;
    public int shotCounter;
    public float shotDelay;
    public float waitDelay;
    public float maxShotDelay;
    public float maxWaitDelay;
    public float maxMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (TurretMain==null || TurretShotSpawn==null || Bullet==null) {
            Destroy(this.gameObject);
        }
        mainScript = this.GetComponent<BasicEnemyScript>();
        if (mainScript == null) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (mainScript.Aggro) {
            if (Physics.Linecast(TurretMain.transform.position, mainScript.player.transform.position)) {
                //mainScript.Aggro = false;
            }
        }
        if (mainScript.Aggro) {



            Vector3 targetLocation = new Vector3(mainScript.player.transform.position.x, TurretMain.transform.position.y, mainScript.player.transform.position.z);
            Vector3 direction = targetLocation- TurretMain.transform.position;
            Quaternion turnDirection = Quaternion.LookRotation(direction);
            
            if (!targetlocked && waitDelay ==0) {

                Vector3 newDir = Vector3.RotateTowards(TurretMain.transform.forward, direction, maxMoveSpeed * Time.deltaTime, 0.0f);
                TurretMain.transform.rotation = Quaternion.LookRotation(newDir);
                if (Mathf.Abs(Quaternion.Angle(TurretMain.transform.rotation, turnDirection)) < 5 && targetlocked == false) {
                    targetlocked = true;
                    shotCounter = 0;
                }
            }
            if (targetlocked) {
                Vector3 newDir = Vector3.RotateTowards(TurretMain.transform.forward, direction, (maxMoveSpeed/2) * Time.deltaTime, 0.0f);
                TurretMain.transform.rotation = Quaternion.LookRotation(newDir);
                if (shotCounter < numShots) {
                    if (shotDelay == 0) {
                        this.attack();
                    }
                } else {
                    waitDelay = maxWaitDelay;
                    targetlocked = false;
                }
            }


        }
        
        if (waitDelay>0) {
            waitDelay -= Time.deltaTime;
        } else {
            waitDelay = 0;
        }
        if (shotDelay>0) {
            shotDelay -= Time.deltaTime;
        } else {
            shotDelay = 0;
        }

    }
    public void attack() {
        shotDelay = maxShotDelay;
        shotCounter += 1;
        Instantiate(this.Bullet,this.TurretShotSpawn.transform.position, this.TurretShotSpawn.transform.rotation);
    }
}
