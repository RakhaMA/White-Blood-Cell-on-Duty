using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArea : MonoBehaviour
{
    public bool isPlayerInArea {get; private set;}
    public Transform playerPos {get; private set;}

    public bool IsPlayerInArea(out Transform playerPosition) {
        playerPosition = playerPos;
        return isPlayerInArea;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isPlayerInArea = true;
            playerPos = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isPlayerInArea = false;
    }
}
