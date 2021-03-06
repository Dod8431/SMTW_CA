﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject networkmanager;
	public SFS2X_Connect connectcomponent;
    public GameObject popUp;
	public int progress = 0;

	void Awake () 
	{
		DontDestroyOnLoad (this);
	}

	void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		networkmanager = GameObject.Find ("Network_Manager");
		connectcomponent = networkmanager.GetComponent<SFS2X_Connect> ();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
    }

	void Update () 
	{
        
		if (connectcomponent.P1_Entrance_Riddle == true || connectcomponent.P1_Puzzle == true || connectcomponent.P2_Puzzle == true || connectcomponent.P2_Puzzle_Minigame == true || connectcomponent.Maze == true || connectcomponent.Narrative == true) {
            GameObject.Find("PopUp").GetComponent<Animator>().Play("PopUpAnim");
            connectcomponent.P1_Entrance_Riddle = false;
            connectcomponent.P1_Puzzle = false;
            connectcomponent.P2_Puzzle = false;
            connectcomponent.P2_Puzzle_Minigame = false;
            connectcomponent.Maze = false;
            connectcomponent.Narrative = false;
        }

        if(connectcomponent.MainScene == true)
        {
            SceneManager.LoadScene(connectcomponent.sceneIndex);
            progress++;
            connectcomponent.MainScene = false;
        }
	}

	public void Button_Scene()
	{
		if (connectcomponent.P1_Entrance_Riddle == true) {
			connectcomponent.P1_Entrance_Riddle = false;
            SceneManager.LoadScene("P1_Entrance_Riddle");
		}

		if (connectcomponent.P1_Puzzle == true) {
			connectcomponent.P1_Puzzle = false;
            SceneManager.LoadScene("P1_Scene");
        }

		if (connectcomponent.P2_Puzzle == true) {
			connectcomponent.P2_Puzzle = false;
            SceneManager.LoadScene("P2_Scene");
        }

		if (connectcomponent.P2_Puzzle_Minigame == true) {
			connectcomponent.P2_Puzzle_Minigame = false;
            SceneManager.LoadScene("P2_Minigame_Scene");
        }

		if (connectcomponent.Maze == true) {
			connectcomponent.Maze = false;
            SceneManager.LoadScene("Maze_Scene");
        }
	}

	public void Reboot()
	{
		progress = 0;	
	}

}
