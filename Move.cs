using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{

    public float speed = 100f;
    public Rigidbody2D rigidbody;
    public float jumpvelocity = 20f;
    public BoxCollider2D boxcollider;
    public LayerMask layer;
    public Animator animator;
   
    private void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        boxcollider = transform.GetComponent<BoxCollider2D>();
       
        
        
        
    }
    void FixedUpdate()
    {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * speed * Time.deltaTime;   
    }

    private void Update()
    {

        

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (Grounded() && Input.GetKeyDown(KeyCode.Space))
        {
           
            rigidbody.velocity = Vector2.up * jumpvelocity;
            transform.position = transform.position + horizontal*Time.deltaTime;
            FindObjectOfType<audiomanager>().Play("PlayerJump");

          
        }
        if (Grounded())
        {
            animator.SetBool("jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("jump", true);
        }


        if (transform.position.y < -25f)
        {
            Destroy(gameObject);
            FindObjectOfType<audiomanager>().Play("EnemyDeath");
            FindObjectOfType<GameManager>().DeathMenu();
            Scoreshow.FinalscoreValue = Score.scoreValue;

        }
       
           
        
        
    }

 

    public bool Grounded()
    {
        RaycastHit2D raycast=Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0f, Vector2.down,.1f,layer);
        return raycast.collider != null;
    }

     
}
