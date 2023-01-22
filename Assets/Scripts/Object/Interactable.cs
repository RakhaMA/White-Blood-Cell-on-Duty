using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent<Interactable> interactTrigger;

    private Animator animator;
    private bool isPlayerDetected;
    protected GameObject player;
    private bool isUsed;

    public bool IsUsed { get => isUsed; set => isUsed = value; }

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        DetectInput();
    }

    public virtual void DetectInput() {
        if (isPlayerDetected && Input.GetButtonDown("Interact") && !IsUsed) {
            if (animator) {
                animator.SetTrigger("Use");
            }
            interactTrigger.Invoke(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            isPlayerDetected = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            isPlayerDetected = false;
            player = null;
        }
    }
}
