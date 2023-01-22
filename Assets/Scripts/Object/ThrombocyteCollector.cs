using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrombocyteCollector : MonoBehaviour
{
    public float spreadDistance = 1f;

    public List<Thrombocyte> thrombocytes;
    private PlayerMovement playerMovement;
    private bool isDeploying;


    private void Start()
    {
        thrombocytes = new List<Thrombocyte>();
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsMoving && !isDeploying)
        {
            CollapseThrombocytePosition();
        }
        else
        {
            SpreadThrombocytePosition();
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.TryGetComponent<Thrombocyte>(out Thrombocyte Thrombocyte)) {
    //         thromboses.Add(Thrombocyte);
    //         Thrombocyte.IsCollected = true;
    //         Debug.Log("thrombocyte colledted");
    //     }
    // }

    public void SpreadThrombocytePosition()
    {
        if (thrombocytes.Count > 0)
        {
            for (int i = 0; i < thrombocytes.Count; i++)
            {
                float radians = 2 * Mathf.PI / thrombocytes.Count * i;

                float vertical = Mathf.Sin(radians);
                float horizontal = Mathf.Cos(radians);

                Vector2 dir = new Vector2(horizontal, vertical);
                Vector2 pos = new Vector2(transform.position.x, transform.position.y) + dir * spreadDistance;

                thrombocytes[i].moveDuration = 0.3f;
                thrombocytes[i].UpdatePosition(pos);

            }
        }
    }

    public void CollapseThrombocytePosition()
    {
        if (thrombocytes.Count > 0)
        {
            
            for (int i = 0; i < thrombocytes.Count; i++)
            {
                Vector2 pos = transform.position;

                thrombocytes[i].UpdatePosition(pos);
            }
        }
    }

    public void DeployThrombosis(List<Vector2> positions, int thrombocyteCount, Transform parent) 
    {
        StartCoroutine(Deployer(positions, thrombocyteCount, parent));
    }

    public IEnumerator Deployer(List<Vector2> positions, int thrombocyteCount, Transform parent)
    {
        if (thrombocytes.Count >= thrombocyteCount)
        {
            isDeploying = true;
            int index = 0;
            
            for (int i = 0; i < thrombocytes.Count; i++)
            {
                Vector2 pos = positions[index];

                thrombocytes[i].UpdatePosition(pos);
                thrombocytes[i].transform.parent = parent;
                parent.gameObject.GetComponent<Thrombosis>().thrombocytes.Add(thrombocytes[i]);
                Debug.Log(thrombocytes[i] + " deployed");
                thrombocytes.RemoveAt(i--);
                index++;
                yield return new WaitForSeconds(0.3f);
            }
            isDeploying = false;
        }
    }
}
