using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

	public SFS2X_Connect network;
    public int index;
    public GameObject notif;
    public GameObject narration;

    void Start () {
		network = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
        Handheld.Vibrate();
    }
	
	void Update () {
		
		index = network.sceneIndex;

        if (index == 3)
        {
            narration.SetActive(true);
            notif.SetActive(false);
        }
        else
        {
            notif.SetActive(true);
            narration.SetActive(false);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(index);
    }
}
