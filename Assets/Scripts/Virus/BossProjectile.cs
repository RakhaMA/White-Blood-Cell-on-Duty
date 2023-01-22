using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : Projectile
{
    protected void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Boss")) {
            base.OnTriggerEnter2D(other);
        }
    }
}
