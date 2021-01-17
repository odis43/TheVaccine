using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public LayerMask layer;
    public LayerMask layertwo;
   
    public PolygonCollider2D box;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x==target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

        if (bulletHit())
        {
            gameObject.SetActive(false);
        }

        if (playerHit())
        {
            gameObject.SetActive(false);
        }

    }

   
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public bool bulletHit()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, layer);
        return raycast.collider != null;
    }
    public bool playerHit()
    {
        RaycastHit2D ray = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, layertwo);
        return ray.collider != null;
    }
}
