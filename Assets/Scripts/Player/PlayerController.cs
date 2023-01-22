using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //buat menyimpan arah pemain
    private float movementInputDirection;
    //buat reference rigidbody dari player
    private Rigidbody2D rb;
    //buat speed
    public float movementSpeed = 10.0f;
    //check arah player
    private bool isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
    }


    
    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 90.0f, 0.0f);
        
    }


    //semua fuction input yang bakal di input user
    private void CheckInput()
    {
        // horizontal reference a dan d  ketika kita pencet a 
        //dia akan output -1 dan ketika pencet d dia akan 1 itu untuk raw
        // kalau hanya get axis aja nanti nilainya dari -1 ke 0 untuk A
        // dan 0 ke 1 untuk D selama dipencet maka angka akan naik
        // nah, gunain raw ini biar langsung -1 atau 1

        movementInputDirection = Input.GetAxisRaw("Horizontal");
    }



   
    private void ApplyMovement()
    {
        //jadi biar bisa maju mundur itu kita main vector terus di update
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        
    }

     


}
