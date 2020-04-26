using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chefMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movem;
    public Animator anim;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Input
        movem.x = Input.GetAxisRaw("Horizontal");
        movem.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movem.x);
        anim.SetFloat("Vertical", movem.y);
        anim.SetFloat("Speed", movem.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movem * movementSpeed * Time.fixedDeltaTime);
    }
}
