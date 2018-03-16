using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Handler : MonoBehaviour {

	public GameObject gamecontroller;

	void Start () 
	{
		gamecontroller = GameObject.Find ("CA_Manager");
	}
	
	void OnClick()
	{
		gamecontroller.GetComponent<GameController> ().BroadcastMessage ("Button_Scene");
	}
}
