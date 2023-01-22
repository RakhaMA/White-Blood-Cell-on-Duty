using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Thrombosis : MonoBehaviour
{
    public Vector2 firstThrombocytePosition;
    public int requiredThrombocyteCount;
    public UnityEvent onDeployed;
    
    public List<Thrombocyte> thrombocytes;
    private List<Vector2> thrombocytePositions;
    private Collider2D col;
    private bool isDeployed;

    public bool IsDeployed { get => isDeployed; set => isDeployed = value; }

    private void Awake() {
        Vector2 thrombocytePosition = firstThrombocytePosition;
        thrombocytePositions = new List<Vector2>();
        thrombocytes = new List<Thrombocyte>();
        col = GetComponent<Collider2D>();
        col.enabled = false;
        for (int i = 0; i < requiredThrombocyteCount; i++) {
            thrombocytePositions.Add(thrombocytePosition);
            thrombocytePosition = new Vector2(thrombocytePosition.x + 1f, thrombocytePosition.y);
        }
    }

    private void Update() {
        if (!IsDeployed && thrombocytes.Count == requiredThrombocyteCount) {
            IsDeployed = true;
            Activate();
        }
    }

    public void Activate() {
        StartCoroutine(ActivateThrombocyte());
    }

    IEnumerator ActivateThrombocyte() {
        foreach (Thrombocyte t in thrombocytes) {
            t.ActivateScaleUp();
            yield return new WaitForSeconds(0.3f);
        }
        col.enabled = true;
        onDeployed.Invoke();
    }

    public Vector2 GetFirstThrombocytePosition() {
        return firstThrombocytePosition;
    }

    public List<Vector2> GetThrombocytePositions() {
        return thrombocytePositions;
    }

    public int GetThrombocyteCount() {
        return requiredThrombocyteCount;
    }
}
