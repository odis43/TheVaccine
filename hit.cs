using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public GameObject bullet;
    public PolygonCollider2D polygon;
    public LayerMask layer;
    private void Start()
    {
        polygon = transform.GetComponent<PolygonCollider2D>();
        bullet = transform.GetComponent<GameObject>();
    }
    void Update()
    {
        if (isHit())
        {
            
            gameObject.SetActive(false);

            FindObjectOfType<audiomanager>().Play("EnemyDeath");
            for(int i = 0; i < 10; i++)
            {
                Score.scoreValue++;
            }
            
        }
    }

    public bool isHit()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(polygon.bounds.center, polygon.bounds.size, 0f, Vector2.down, .1f, layer);
        return raycast.collider != null;
    }
}
