using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float distanceAhead = 2;
    [SerializeField] private float cameraSpeed = 2;
    private float lookAhead;
    public Vector2 cameraBoundMinValue, cameraBoundMaxValue;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow() {
        
        lookAhead = Mathf.Lerp(lookAhead, (distanceAhead * player.localScale.x), Time.deltaTime * cameraSpeed);

        Vector3 targetPosition = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, cameraBoundMinValue.x, cameraBoundMaxValue.x),
            Mathf.Clamp(targetPosition.y, cameraBoundMinValue.y, cameraBoundMaxValue.y),
            targetPosition.z
        );

        transform.position = boundPosition;
    }
}
