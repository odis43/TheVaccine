using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGroundEnemy : MonoBehaviour
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
           
        }
    }

    public bool isHit()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(polygon.bounds.center, polygon.bounds.size, 0f, Vector2.down, .1f, layer);
        return raycast.collider != null;
    }
}
