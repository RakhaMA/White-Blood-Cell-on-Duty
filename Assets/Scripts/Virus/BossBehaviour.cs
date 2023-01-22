using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject[] platforms;
    private Health bossHealth;
    public GameObject basicVirus;
    public GameObject movingVirus;

    public GameObject[] spawnSpots;



    // Start is called before the first frame update
    void Start()
    {
        bossHealth = GetComponent<Health>();



    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth.currentHealth == 15)
        {
            firstMech();
        }

        if(bossHealth.currentHealth == 10)
        {
            secondMech();
        }

        if(bossHealth.currentHealth == 5)
        {
            thirdMech();
        }
        
    }

    public void firstMech()
    {
        for(int i=0;i<3;i++)
        {
            platforms[i].SetActive(false);
        }

        for(int i=1;i<4;i++)
        {
            Instantiate(basicVirus, new Vector3(spawnSpots[i].transform.position.x, spawnSpots[i].transform.position.y +1f, spawnSpots[i].transform.position.z), Quaternion.identity);
        }

    }

    public void secondMech()
    {
        for(int i=3;i<6;i++)
        {
            platforms[i].SetActive(false);
        }

        for(int i=1;i<4;i++)
        {
            Instantiate(basicVirus, new Vector3(spawnSpots[i].transform.position.x, spawnSpots[i].transform.position.y +1f, spawnSpots[i].transform.position.z), Quaternion.identity);
        }

    }


    public void thirdMech()
    {
        Vector3 spawnPosition3 = new Vector3(spawnSpots[0].transform.position.x, spawnSpots[0].transform.position.y + 2f, spawnSpots[0].transform.position.z);

        Instantiate(movingVirus, spawnPosition3, Quaternion.identity);
    }


}
