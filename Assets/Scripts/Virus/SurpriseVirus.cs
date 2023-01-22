using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseVirus : BasicVirus
{
    private bool isTriggered;

    private Collider2D col;
    private Rigidbody2D rb;

    private void Start() {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    public void Surprise() {
        if (!isTriggered) {
            isTriggered = true;
            col.isTrigger = true;
            rb.isKinematic = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        if (other.gameObject.layer == 7) {
            rb.isKinematic = true;
            col.isTrigger = true;
        }

        if (other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.layer == 7) {
            Debug.Log("jatoh");
            rb.isKinematic = false;
            col.isTrigger = false;
            // rb.isKinematic = true;
            
            // col.isTrigger = true;
        }
    }
}
