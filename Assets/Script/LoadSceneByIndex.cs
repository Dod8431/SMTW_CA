using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

    public GameObject networkmanager;
    public SFS2X_Connect connectcomponent;
    public int index;
    public GameObject notif;
    public GameObject narration;

    void Start () {
        networkmanager = GameObject.Find("Network_Manager");
        connectcomponent = networkmanager.GetComponent<SFS2X_Connect>();
        Handheld.Vibrate();
    }
	
	void Update () {
        index = connectcomponent.sceneIndex;

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
