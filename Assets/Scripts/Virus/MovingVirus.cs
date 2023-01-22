using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVirus : BasicVirus
{
    public float rotation = 3f;
    public float speed = 2f;
    public float leftLimit, rightLimit;

    private Rigidbody2D rb;
    private float movementRotation;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementRotation = rotation;
        direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Vector2.right) {
            movementRotation = rotation;
        } else {
            movementRotation = -rotation;
        }

        transform.Rotate(transform.forward, movementRotation);
        rb.velocity = speed * direction;

        if (transform.position.x <= leftLimit) {
            direction = Vector2.right;
        }

        if (transform.position.x >= rightLimit) {
            direction = Vector2.left;
        }
    }

    public void Die() {

    }
}
