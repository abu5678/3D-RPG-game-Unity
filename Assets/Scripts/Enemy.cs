using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float attackDistance;
    public int damage;
    public int health;

    public bool isAttacking;
    public bool isDead;

    public NavMeshAgent agent;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        //checks to see if the enemy is within attack range of the player
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            agent.isStopped = true;
            if (!isAttacking)
            {
                Attack();
            }

        }
        else
        {
            agent.isStopped = false;
            //will chase the player
            agent.SetDestination(player.transform.position);
            animator.SetBool("Running", true);
        }
    }

    void Attack()
    {
        isAttacking = true;
        animator.SetBool("Running", false);
        animator.SetTrigger("Attack");
        //creates a delay 
        Invoke("TryDamage", 1.3f);
        Invoke("StopAttacking", 2.66f);
    }
    void TryDamage()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            player.takeDamage(damage);
        }
    }
    void StopAttacking()
    {
        isAttacking = false;
    }
    public void takeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            isDead = true;
            agent.isStopped = true;
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
        }
    }
}
