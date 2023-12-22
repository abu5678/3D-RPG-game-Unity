using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;

    private void Move()
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
