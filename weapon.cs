using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public float force = 20f;
    public Vector2 look;
    public float angle;



    // Update is called once per frame
   
    void Update()
    {
        look = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        firepoint.rotation = Quaternion.Euler(0f, 0f, angle );
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            FindObjectOfType<audiomanager>().Play("PlayerShoot");
        }
       
    }
    
    void Shoot()
    {
       
            GameObject B = Instantiate(bullet, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = B.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * force, ForceMode2D.Impulse);
        
        
    }
}
