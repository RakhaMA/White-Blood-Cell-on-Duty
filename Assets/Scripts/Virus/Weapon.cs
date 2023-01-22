using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ShootArea shootArea;
    public float shootDelay = 2f;
    public GameObject projectilePrefab;

    private float shootTimer = 0f;
    private Transform playerPosition;
    private Vector3 targetPosition;

    private void Update() {

        shootTimer += Time.deltaTime;

        if (shootArea.IsPlayerInArea(out playerPosition)) {
            targetPosition = playerPosition.position - transform.position;
            LookAtPlayer(targetPosition);
            
            if (shootTimer >= shootDelay) {
                Shoot();
            }
        } 
        else 
        {
            transform.up = Vector3.down;
        }
    }

    private void LookAtPlayer(Vector3 target) {
        transform.up = target;
    }

    private void Shoot() {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.up, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetDirection(targetPosition);
        projectile.GetComponent<Projectile>().SetIgnoredGameobject(transform.parent.gameObject);
        shootTimer = 0f;
    }
}
