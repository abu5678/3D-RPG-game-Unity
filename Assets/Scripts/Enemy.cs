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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) 
            return;
        //checks to see if the enemy is within attack range of the player
        if(Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            agent.isStopped = true;

        }
        else
        {
            agent.isStopped = false;
            //will chase the player
            agent.SetDestination(player.transform.position);
        }
    }

}
