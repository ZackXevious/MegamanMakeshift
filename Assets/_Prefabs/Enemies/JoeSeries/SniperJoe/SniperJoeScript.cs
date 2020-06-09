using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SniperJoeScript : MonoBehaviour
{
    public GameObject target;
    public GameObject enemyRotationControl;
    public SniperJoeAnimator SniperJoeAnim;
    public NavMeshAgent navAgent;
    BasicEnemyScript enemyScript;
    public Vector3 originalPosition;

    [Header("RandomMoving Related stuff")]
    public float Distance;
    public Vector3 newDirection;
    public float RandomWaitDuration;
    public float RandomWaitTime;

    [Header("Projectile based stuff")]
    public GameObject shotSpawn;
    public GameObject bullet;
    public float shotWaitDuration=3;
    public float shotWaitTime;
    public int currentShots;
    public int maxShots;
    public float inBetweenShots;
    public float inBetweenDuration=.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindObjectOfType<CameraControls>().gameObject;
        navAgent = this.GetComponent<NavMeshAgent>();
        if (SniperJoeAnim==null) {
            SniperJoeAnim = this.GetComponentInChildren<SniperJoeAnimator>();
        }
        enemyScript = this.GetComponent<BasicEnemyScript>();
        this.originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate() {
        
        if (target != null) {
            enemyRotationControl.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        


        if (enemyScript.Aggro) {
            if (target == null) {
                target = GameObject.FindGameObjectWithTag("Player");
            } else {
                
                Vector3 rotateTowards = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
                
                SniperJoeAnim.setMoveSpeed(Mathf.Clamp(Mathf.Abs(navAgent.velocity.x) + Mathf.Abs(navAgent.velocity.y), 0, 1));


                if (Vector3.Distance(this.transform.position,target.transform.position)>Distance||Physics.Linecast(this.transform.position,enemyScript.player.transform.position)) {
                    this.navAgent.SetDestination(this.GetComponent<BasicEnemyScript>().player.transform.position);
                    this.resetRandomDirection();
                    //Debug.Log(Physics.Linecast(this.transform.position, enemyScript.player.transform.position));
                } else if(RandomWaitTime<=0){
                    //Code to move erratically
                    newDirection = new Vector3(Random.Range(-5,5),0,Random.Range(-5,5));
                    RandomWaitTime = RandomWaitDuration;
                    
                } else {
                    this.navAgent.SetDestination(this.transform.position + newDirection);
                    RandomWaitTime -= Time.deltaTime;
                }
                
                
            }
            if (shotWaitTime<=0) {
                //SniperJoeAnim.setTarget(target.transform);
                this.navAgent.SetDestination(this.transform.position);
                //this.transform.LookAt(this.shotSpawn.transform);
                if (currentShots<maxShots) {
                    enemyRotationControl.transform.LookAt(GameObject.FindGameObjectWithTag("Strafe").transform.position);
                    if (inBetweenShots<=0) {
                        this.FireProjectile();
                        currentShots += 1;
                        inBetweenShots = inBetweenDuration;
                    } else {
                        inBetweenShots -= Time.deltaTime;
                    }
                    
                } else {
                    this.shotWaitTime = shotWaitDuration;
                    inBetweenShots = 0;
                    currentShots = 0;
                }
                
                
            } else {
                if (shotWaitTime<1) {
                    SniperJoeAnim.setTarget(this.shotSpawn.transform);
                }
                shotWaitTime -= Time.deltaTime;
            }
        } else {
            /*
            if (Vector3.Distance(this.transform.position,originalPosition)>Distance) {
                this.navAgent.SetDestination(this.originalPosition);
            } else {
                this.navAgent.SetDestination(this.originalPosition + new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25)));
            }*/
            this.resetTarget();
            
        }
        
        
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("PlayerAttack")|| collision.collider.CompareTag("Player")) {
            this.resetRandomDirection();
        }
    }

    public void resetTarget() {
        target = null;
        //SniperJoeAnim.setTarget(null);
    }

    public void FireProjectile() {
        Instantiate(this.bullet, this.shotSpawn.transform.position, this.shotSpawn.transform.rotation);
        
        //this.resetRandomDirection();
    }

    public void resetRandomDirection() {
        //Debug.Log("getting new random direction");
        RandomWaitTime = 0;
    }
    
}
