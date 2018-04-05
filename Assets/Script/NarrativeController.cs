using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativeController : MonoBehaviour {

    public SFS2X_Connect sfs;
    public int narrativeindex;

    public GameObject fresque1;
    public GameObject fresque2;
    public GameObject fresque3;

    void Start ()
    {
        sfs = GameObject.Find("Network_Manager").GetComponent<SFS2X_Connect>();
	}
	
	
	void Update ()
    {
        narrativeindex = sfs.narrativeIndex;
        if(narrativeindex == 1)
        {
            fresque3.SetActive(false);
            fresque2.SetActive(false);
            fresque1.SetActive(true);
        }
        if (narrativeindex == 2)
        {
            fresque3.SetActive(false);
            fresque2.SetActive(true);
            fresque1.SetActive(false);
        }
        if (narrativeindex == 3)
        {
           fresque3.SetActive(true);
            fresque2.SetActive(false);
            fresque1.SetActive(false);
        }
    }
    
    public void Return1()
    {
		sfs.BroadcastMessage ("Narrative_End1");
        SceneManager.LoadScene(2);
    }

    public void Return21()
    {
        sfs.BroadcastMessage("Narrative_End2");
        SceneManager.LoadScene(2);
    }
}
