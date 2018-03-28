using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject networkmanager;
	public SFS2X_Connect connectcomponent;
    GameObject popUp;
	public int progress = 0;

	void Awake () 
	{
		DontDestroyOnLoad (this);
	}

	void Start()
	{
		networkmanager = GameObject.Find ("Network_Manager");
		connectcomponent = networkmanager.GetComponent<SFS2X_Connect> ();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "CA_Main_Scene") {
          popUp = GameObject.Find("PopUp");
        }
    }

	void Update () 
	{
        
		if (connectcomponent.P1_Entrance_Riddle == true || connectcomponent.P1_Puzzle == true || connectcomponent.P2_Puzzle == true || connectcomponent.P2_Puzzle_Minigame == true || connectcomponent.Maze == true) {
            popUp.SetActive(true);
		}
	}

	public void Button_Scene()
	{
		if (connectcomponent.P1_Entrance_Riddle == true) {
			connectcomponent.P1_Entrance_Riddle = false;
			progress += 1;
			SceneManager.LoadScene ("P1_Entrance_Riddle");
		}

		if (connectcomponent.P1_Puzzle == true) {
			connectcomponent.P1_Puzzle = false;
			progress += 1;
			SceneManager.LoadScene ("P1_Scene");
		}

		if (connectcomponent.P2_Puzzle == true) {
			connectcomponent.P2_Puzzle = false;
			progress += 1;
			SceneManager.LoadScene ("P2_Scene");
		}

		if (connectcomponent.P2_Puzzle_Minigame == true) {
			connectcomponent.P2_Puzzle_Minigame = false;
			progress += 1;
			SceneManager.LoadScene ("P2_Minigame_Scene");
		}

		if (connectcomponent.Maze == true) {
			connectcomponent.Maze = false;
			progress += 1;
			SceneManager.LoadScene ("Maze_Scene");
		}
	}

}
