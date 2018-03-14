using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject networkmanager;

	void Awake () 
	{
		DontDestroyOnLoad (this);
	}

	void Start()
	{
		networkmanager = GameObject.Find ("Network_Manager");
	}

	void Update () 
	{
		if (networkmanager.GetComponent<SFS2X_Connect> ().P1_Entrance_Riddle == true) {
			SceneManager.LoadScene ("P1_Entrance_Riddle");
			networkmanager.GetComponent<SFS2X_Connect> ().P1_Entrance_Riddle = false;
		}
	}
}
