using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraZoomOutBoss : MonoBehaviour
{
    // public Transform player;
    // public Vector2 cameraBoundMinValue, cameraBoundMaxValue;
    public float zoomSize = 5;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public bool isPlayerInArea()
    // {
    //     if(player.position.x >= cameraBoundMinValue.x && player.position.x <= cameraBoundMaxValue.x )
    //     {

    //     }
    // }
    public void zoomOut()
    {
        GetComponent<Camera>().orthographicSize = zoomSize + 5;
    }

    public void zoomIn()
    {
        GetComponent<Camera>().orthographicSize = zoomSize;
    }

    
}
