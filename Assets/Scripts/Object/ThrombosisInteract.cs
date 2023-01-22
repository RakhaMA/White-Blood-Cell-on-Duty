using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrombosisInteract : Interactable
{
    public Thrombosis thrombosis;
    private int requiredThrombocyteCount;

    public int RequiredThrombocyteCount { get => requiredThrombocyteCount; set => requiredThrombocyteCount = value; }

    private void Start() {
        RequiredThrombocyteCount = thrombosis.GetThrombocyteCount();
        
    }

    void Update()
    {
        DetectInput();
        if (thrombosis.IsDeployed) {
            GetComponent<ParticleSystem>().Stop();
            gameObject.SetActive(false);
        }
    }

    public override void DetectInput() {
        base.DetectInput();
    }

    public void DeployThrombosis() {
        if (player) {
            player.GetComponentInChildren<ThrombocyteCollector>().DeployThrombosis(
                thrombosis.GetThrombocytePositions(),
                thrombosis.GetThrombocyteCount(),
                thrombosis.transform
            );
        }
        
    }

    public void DebugInput() {
        Debug.Log("Thrombosis Interacted");
    }
}
