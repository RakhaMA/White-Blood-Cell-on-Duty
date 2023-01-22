using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    public float lifetime = 4f;
    public int damage = 1;

    private Vector3 direction;
    private float timer;
    private GameObject ignoredGameobject;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += direction * speed * Time.deltaTime;

        if (timer > lifetime) {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction) {
        this.direction = direction;
    }

    public void SetScale(Vector3 newScale) {
        transform.localScale = new Vector3(newScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void SetIgnoredGameobject(GameObject gameObject) {

    }

    protected void OnTriggerEnter2D(Collider2D other) {

        if (!other.CompareTag("ShootArea") && other.gameObject != ignoredGameobject && !other.CompareTag("Not Target")) {
            if (other.gameObject.TryGetComponent<Health>(out Health health)) {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
