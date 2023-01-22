using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent theEvent;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Not Target") && !other.gameObject.CompareTag("Virus")) {
            theEvent.Invoke();
        }   
    }
}
