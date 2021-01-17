using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform Player;
    public float ms = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public PolygonCollider2D box;
    public LayerMask L;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject bullet;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        box = transform.GetComponent<PolygonCollider2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 direction = Player.position-transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if (isTouching())
        {
            Player.position.x.Equals(0);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            FindObjectOfType<audiomanager>().Play("EnemyShoot");

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
         
    }

    
    private void FixedUpdate()
    {
        moveC(movement);
        
    }
    void moveC(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * ms * Time.deltaTime));
        
    }
    public bool isTouching()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, L);
        return raycast.collider != null;
    }
}
