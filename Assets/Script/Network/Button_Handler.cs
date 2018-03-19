using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Handler : MonoBehaviour {

	public GameObject gamecontroller;

	void Start () 
	{
		gamecontroller = GameObject.Find ("CA_Manager");
	}
	
	public void LoadingScene()
	{
		gamecontroller.GetComponent<GameController> ().BroadcastMessage ("Button_Scene");
	}
}
