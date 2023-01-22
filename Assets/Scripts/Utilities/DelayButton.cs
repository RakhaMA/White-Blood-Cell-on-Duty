using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayButton : MonoBehaviour
{
    public GameObject button;

    [SerializeField] private float buttonUpTime = 10f;

    void Start()
    {
        button.SetActive(false);

        Invoke("activateButton", buttonUpTime);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateButton()
    {
        button.SetActive(true);
    }
}
