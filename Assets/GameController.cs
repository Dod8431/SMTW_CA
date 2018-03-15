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

		if (networkmanager.GetComponent<SFS2X_Connect> ().P1_Puzzle == true) {
			SceneManager.LoadScene ("P1_Scene");
			networkmanager.GetComponent<SFS2X_Connect> ().P1_Puzzle = false;
		}

		if (networkmanager.GetComponent<SFS2X_Connect> ().P2_Puzzle == true) {
			SceneManager.LoadScene ("P2_Scene");
			networkmanager.GetComponent<SFS2X_Connect> ().P2_Puzzle = false;
		}

		if (networkmanager.GetComponent<SFS2X_Connect> ().P2_Puzzle_Minigame == true) {
			SceneManager.LoadScene ("P2_Minigame_Scene");
			networkmanager.GetComponent<SFS2X_Connect> ().P2_Puzzle_Minigame = false;
		}

		if (networkmanager.GetComponent<SFS2X_Connect> ().Maze == true) {
			SceneManager.LoadScene ("Maze_Scene");
			networkmanager.GetComponent<SFS2X_Connect> ().Maze = false;
		}
	}
}
