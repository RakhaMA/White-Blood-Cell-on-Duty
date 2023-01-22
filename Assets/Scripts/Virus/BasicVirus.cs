using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicVirus : MonoBehaviour
{
    public int damage = 1;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enemy");
        if (other.TryGetComponent<Health>(out Health health))
        {
            Debug.Log("health take damage");
            health.TakeDamage(damage);
        }
    }
}
