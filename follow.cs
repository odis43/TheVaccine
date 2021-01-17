
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player;
    public Vector2 offset;
    public float smoothSpeed = 0.2f;
    void FixedUpdate()
    {
        offset.y = transform.position.y;
       
        Vector3 desired = player.position;
        Vector3 smooth = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
        transform.position = smooth;
    }
}
