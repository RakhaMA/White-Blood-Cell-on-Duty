using UnityEngine;

public class Thrombocyte : MonoBehaviour
{
    public float moveDuration = 0.5f;
    public float scaleUpDuration = 0.5f;
    public Vector3 scaleUpScale = new Vector3(0.5f, 0.5f, 0.5f);
    
    private float elapsedTime;
    private float scaleUpTimer;
    private Vector3 newPosition;
    private Vector3 startPosition;
    private Vector3 orbitCenter;
    private float orbitSpeed;
    private bool isCollected;
    private bool isScalingUp;

    public bool IsCollected { get => isCollected; set => isCollected = value; }

    private void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected) {
            Move();
        }

        if (isScalingUp) {
            ScaleUp();
        }
    }

    public void Move() {
        if (transform.position != newPosition) {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / moveDuration;
            transform.position = Vector3.Lerp(startPosition, newPosition, percentageComplete);
        } else {
            startPosition = transform.position;
            elapsedTime = 0;
        }
    }

    public void UpdatePosition(Vector3 newPos) {
        newPosition = newPos;
    }

    public void ActivateScaleUp() {
        isScalingUp = true;
    }

    private void ScaleUp() {
        scaleUpTimer += Time.deltaTime;
        float percentage = scaleUpTimer / scaleUpDuration;
        transform.localScale = Vector3.Lerp(transform.localScale, scaleUpScale, percentage);
        if (transform.localScale.x >= scaleUpScale.x) {
            isScalingUp = false;
            scaleUpTimer = 0f;
            this.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (other.transform.Find("ThrombocyteCollector").TryGetComponent<ThrombocyteCollector>(out ThrombocyteCollector collector)) {
                if (!collector.thrombocytes.Contains(this)) {
                    if (!isCollected) {
                        collector.thrombocytes.Add(this);
                        transform.parent = collector.transform;
                        isCollected = true;
                        Debug.Log("thrombocyte collected");
                    }
                    
                }
            }
        }
    }
}
