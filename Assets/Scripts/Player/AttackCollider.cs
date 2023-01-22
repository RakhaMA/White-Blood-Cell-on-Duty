using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Player")) {
            if (other.TryGetComponent<Health>(out Health health)) {
                health.TakeDamage(damage);
            }
        }
    }
}
