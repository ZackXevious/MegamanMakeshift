using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float FightDelay;
    public float maxFightDelay;
    public float leftShootDelay;
    public float rightShootDelay;
    public float MaxShootDelay;
    public BossAnimationScript anim;
    public BasicEnemyScript mainScript;

    public GameObject LeftShotSpawn;
    public GameObject RightShotSpawn;
    public GameObject projectile;
    public float FireDelay;
    public float MaxFireDelay;

    public GameObject[] flightTargets;
    public int CurrFlightTarget;
    public float moveSpeed;
    public float MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        FightDelay = maxFightDelay;
        anim = GetComponentInChildren<BossAnimationScript>();
        mainScript = this.GetComponent<BasicEnemyScript>();
        CurrFlightTarget = 0;
        MaxHealth = mainScript.health;
    }
    void FixedUpdate() {
        if (mainScript.player==null) {
            FightDelay = maxFightDelay;
        }
        if (FightDelay<=0) {
            anim.SetTarget(GameObject.FindGameObjectWithTag("Strafe"));
            if (Vector3.Distance(this.transform.position, flightTargets[CurrFlightTarget].transform.position)<.1) {
                CurrFlightTarget = Random.Range(1,flightTargets.Length-1);
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position,flightTargets[CurrFlightTarget].transform.position,moveSpeed);
            this.transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag("Strafe").transform.position.x, this.transform.position.y, GameObject.FindGameObjectWithTag("Strafe").transform.position.x));

            //Shooting
            if (mainScript.health>MaxHealth/2) {
                if (leftShootDelay <= 0) {
                    leftShootDelay = MaxShootDelay;
                } else {
                    if (leftShootDelay <= MaxShootDelay / 2) {
                        anim.leftTarget = true;
                    } else {
                        anim.leftTarget = false;
                    }

                    leftShootDelay -= Time.deltaTime;
                }
                if (rightShootDelay <= 0) {
                    rightShootDelay = MaxShootDelay;

                } else {
                    if (rightShootDelay <= MaxShootDelay / 2) {
                        anim.rightTarget = true;
                    } else {
                        anim.rightTarget = false;
                    }

                    rightShootDelay -= Time.deltaTime;
                }
                if (FireDelay <= 0) {
                    if (rightShootDelay <= MaxShootDelay / 2) {
                        Instantiate(projectile, RightShotSpawn.transform.position, RightShotSpawn.transform.rotation);
                    } else if (leftShootDelay <= MaxShootDelay / 2) {
                        Instantiate(projectile, LeftShotSpawn.transform.position, LeftShotSpawn.transform.rotation);
                    }
                    FireDelay = MaxFireDelay*Mathf.Clamp((mainScript.health/MaxHealth),.5f,1);
                } else {
                    FireDelay -= Time.deltaTime;
                }
            } else {
                rightShootDelay = 0;
                leftShootDelay = 0;
                anim.leftTarget = true;
                anim.rightTarget = true;
                if (FireDelay <= 0) {
                    Instantiate(projectile, LeftShotSpawn.transform.position, LeftShotSpawn.transform.rotation);
                    Instantiate(projectile, RightShotSpawn.transform.position, RightShotSpawn.transform.rotation);
                    FireDelay = MaxFireDelay/2;
                } else {
                    FireDelay -= Time.deltaTime;
                }
            }
            
        } else {
            FightDelay -= Time.deltaTime;
        }
    }


}
