using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

    public GameObject networkmanager;
    public SFS2X_Connect connectcomponent;
    int index;
    // Use this for initialization
    void Start () {
        networkmanager = GameObject.Find("Network_Manager");
        connectcomponent = networkmanager.GetComponent<SFS2X_Connect>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene()
    {
        index = connectcomponent.sceneIndex;
        SceneManager.LoadScene(index);
    }
}
