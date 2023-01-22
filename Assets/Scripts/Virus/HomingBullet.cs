using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingBullet : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    private Rigidbody2D rb;
    public float rotateSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;

    //     transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
