using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    bool isStopping;
    Vector2 direction;
    public float speed = 2f;
    public Vector2 MovementMinLimit;
    public Vector2 MovementMaxLimit;
    public float platformStopDelay = 1f;

    private float platformStopTimer = 0f;
    private float moveSpeed;

    public bool isOneWay;
    public bool isVerticalMovement;
    public FirstMoveDirection firstMoveDirection;

    public enum FirstMoveDirection
    {
        Up, Down, Right, Left
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch (firstMoveDirection)
        {
            case FirstMoveDirection.Up:
                direction = MovementMaxLimit;
                break;

            case FirstMoveDirection.Down:
                direction = MovementMinLimit;
                break;

            case FirstMoveDirection.Right:
                direction = MovementMaxLimit;
                break;

            case FirstMoveDirection.Left:
                direction = MovementMinLimit;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (platformStopTimer > 0)
        {
            isStopping = true;
        }
        else
        {
            isStopping = false;
        }

        if (!isStopping)
        {
            moveSpeed = speed;            
        }
        else
        {
            moveSpeed = 0f;
            platformStopTimer -= Time.deltaTime;
        }

        

        transform.position = Vector2.MoveTowards(transform.position, direction, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, direction) == 0) {
            if (isOneWay) {
                Destroy(this);
            }
            platformStopTimer = platformStopDelay;
            GetNewDirection();
        }

        // if (isVerticalMovement)
        // {
        //     if (transform.position.y > MovementMaxLimit.y && !isStopping)
        //     {
        //         if (isOneWay == true)
        //         {
        //             Destroy(rb);
        //             Destroy(this);
        //         }
        //         platformStopTimer = platformStopDelay;
        //         transform.position = MovementMaxLimit;
        //         direction = Vector2.down;
        //     }

        //     if (transform.position.y < MovementMinLimit.y && !isStopping)
        //     {
        //         if (isOneWay == true)
        //         {
        //             Destroy(rb);
        //             Destroy(this);
        //         }
        //         platformStopTimer = platformStopDelay;
        //         transform.position = MovementMinLimit;
        //         direction = Vector2.up;
        //     }
        // }
        // else {
        //     if (transform.position.x > MovementMaxLimit.x && !isStopping)
        //     {
        //         if (isOneWay == true)
        //         {
        //             Destroy(rb);
        //             Destroy(this);
        //         }
        //         platformStopTimer = platformStopDelay;
        //         transform.position = MovementMaxLimit;
        //         direction = Vector2.left;
        //     }

        //     if (transform.position.x < MovementMinLimit.x && !isStopping)
        //     {
        //         if (isOneWay == true)
        //         {
        //             Destroy(rb);
        //             Destroy(this);
        //         }
        //         platformStopTimer = platformStopDelay;
        //         transform.position = MovementMinLimit;
        //         direction = Vector2.right;
        //     }
        // }
    }

    public void GetNewDirection() {
        if (direction == MovementMaxLimit) {
            direction = MovementMinLimit;
        }
        else {
            direction = MovementMaxLimit;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.collider.TryGetComponent<PlayerMovement>(out PlayerMovement player)) {
            Debug.Log("Platform set parent");
            player.SetParent(transform);
        }

    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.TryGetComponent<PlayerMovement>(out PlayerMovement player)) {
            Debug.Log("Platform reset parent");
            player.ResetParent();
        }
    }

}
