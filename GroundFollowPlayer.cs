using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollowPlayer : MonoBehaviour
{
    public Transform Player;
    public float ms = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public PolygonCollider2D box;
    public LayerMask L;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        box = transform.GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Player.position ;
        
       
        direction.Normalize();
        movement = direction;
        if (isTouching())
        {
            Player.position.x.Equals(0);
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
