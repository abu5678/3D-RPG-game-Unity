using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float JumpForce;
    public Rigidbody rig;

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
}
