using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public float moveSpeed;
    public float JumpForce;
    public Rigidbody rig;

    public float attackRange;
    public int damage;
    public bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //check if user clicks left mouse and is not currently attacking, (1 is for right mouse , 2 is for middle mouse)
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }
    }
    void Move()
    {
        //-1 for left, 1 for right
        float x = Input.GetAxis("Horizontal");
        //-1 for backwards,1 for forward
        float z = Input.GetAxis("Vertical");

        //makes it so that player moves based on camera direction
        Vector3 direction = transform.right * x + transform.forward * z;
        direction *= moveSpeed;
        //makes it so that you can fall and not float 
        direction.y = rig.velocity.y;

        rig.velocity = direction;
    }
    void Jump()
    {
        if (canJump())
        {
            rig.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
        }
    }

    bool canJump()
    {
        //uses raycast to see if the player is on the floor
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,0.1f))
        {
            //check if the raycast hit the floor
            return hit.collider != null;
        }
        return false;
    }
    public void takeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0)
        {
            //restarts the scene when the player has 0 or less health
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
    }
    private void Attack()
    {
        isAttacking = true;
        //creates a delay 
        Invoke("TryDamage", 0.7f);
        Invoke("StopAttacking", 1.5f);
    }
    void TryDamage()
    {
        //sphere cast, check what objects are within sphere
        Ray ray = new Ray(transform.position + transform.forward, transform.forward);
        //creates spehere size of player attack range and checks for layer 6 which is enemy
        RaycastHit[] hits = Physics.SphereCastAll(ray,attackRange,1 << 6);

        foreach (RaycastHit hit in hits)
        {
            hit.collider.GetComponent<Enemy>().takeDamage(damage);
        }
    }
    void StopAttacking()
    {
        isAttacking = false;
    }
}
