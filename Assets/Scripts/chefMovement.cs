using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chefMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movem;
    public Animator anim;
    public GameObject cookPot;
    
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

        cookPot = GameObject.Find("cookPot");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, cookPot.transform.position, Mathf.Infinity, LayerMask.GetMask("cookingPot"));
        if (hit.collider != null)
        {
            var pos = Vector2.Distance(transform.position, hit.collider.gameObject.transform.position);
            print("The Cooking pot is " + pos + " studs from the Chef");
        }
    }
}
