
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public PolygonCollider2D box;
    public LayerMask layer;
    public LayerMask layertwo;
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void Update()
    {
        if (bulletHit())
        {
            gameObject.SetActive(false);
        }

        if (enemyHit())
        {
            gameObject.SetActive(false);
        }
        
    }
    public bool bulletHit()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, layer);
        return raycast.collider != null;
    }
    public bool enemyHit()
    {
        RaycastHit2D ray = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, .1f, layertwo);
        return ray.collider != null;
    }   
}
