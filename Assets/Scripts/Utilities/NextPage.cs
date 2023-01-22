using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    [Header("Panel List")]
    public GameObject[] Panel;
    // public GameObject Panel1;
    // public GameObject Panel2;
    // public GameObject Panel3;
    // public GameObject Panel4;
    // public GameObject Panel5;
    // public GameObject Panel6;
    // public GameObject Panel7;



    // Start is called before the first frame update
    void Start()
    {
        // Panel1.SetActive(true);
        // Panel2.SetActive(false);
        // Panel3.SetActive(false);
        // Panel4.SetActive(false);
        // Panel5.SetActive(false);
        // Panel6.SetActive(false);
        // Panel7.SetActive(false);

        Panel[0].SetActive(true);
        for(int i=1;i<Panel.Length;i++)
        {
            Panel[i].SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void panel1Button()
    {
        Panel[0].SetActive(false);
        Panel[1].SetActive(true);
    }

    public void panel2Button()
    {
        Panel[1].SetActive(false);
        Panel[2].SetActive(true);
    }

    public void panel3Button()
    {
        Panel[2].SetActive(false);
        Panel[3].SetActive(true);
    }

    public void panel4Button()
    {
        Panel[3].SetActive(false);
        Panel[4].SetActive(true);
    }

    public void panel5Button()
    {
        Panel[4].SetActive(false);
        Panel[5].SetActive(true);
    }

    public void panel6Button()
    {
        Panel[5].SetActive(false);
        Panel[6].SetActive(true);
    }

    // public void panel7Button()
    // {
    //     Panel1.SetActive(false);
    //     Panel2.SetActive(true);
    // }


}
