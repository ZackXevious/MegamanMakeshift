using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MetEnemyScript : MonoBehaviour
{
    [Header("Basic Enemy Script(Important)")]
    BasicEnemyScript enemyScript;
    [Header("variables")]
    public float currentwait;
    public float maxWait=3;
    public float AttackDelay;
    public float maxAttackDelay=3;

    public NavMeshAgent agent;
    [Header("Explosion when dead")]
    public GameObject deathSpawn;
    [Header("Attack")]
    public GameObject shotSpawn;
    public GameObject LongRange;
    public GameObject ShortRange;

    [Header("AnimationStuff")]
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        enemyScript = this.GetComponent<BasicEnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {

        if (enemyScript.Aggro) {
            if (currentwait==0) {
                if (AttackDelay==0) {
                    this.LongRangeAttack();
                }
                agent.SetDestination(enemyScript.player.transform.position);
                anim.SetFloat("IsRunning",1);
            } else {
                agent.SetDestination(this.transform.position);
                AttackDelay = maxAttackDelay;
                anim.SetFloat("IsRunning", 0);
            }
        } else {
            agent.SetDestination(this.transform.position);
            AttackDelay = maxAttackDelay;
            anim.SetFloat("IsRunning", 0);
        }



        if (currentwait>0) {
            currentwait -= Time.deltaTime;
        } else {
            currentwait = 0;
        }
        if (AttackDelay>0) {
            AttackDelay -= Time.deltaTime;
        } else {
            AttackDelay = 0;
        }


        if (currentwait>0) {
            anim.SetFloat("IsHiding", currentwait);
        }
        if (AttackDelay>0) {

        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Player")) {
            this.ShortRangeAttack();
        }
    }
    private void LongRangeAttack() {
        agent.transform.LookAt(enemyScript.player.transform);
        
        if (this.LongRange != null) {
            Instantiate(this.LongRange, shotSpawn.transform.position, shotSpawn.transform.rotation);
        }
        currentwait = maxWait;
    }
    private void ShortRangeAttack() {
        if (this.ShortRange != null) {
            Instantiate(this.ShortRange, this.transform);
        }
        currentwait = maxWait;
    }
}
