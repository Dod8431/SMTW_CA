using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PZ1_GC : MonoBehaviour {

	public bool slot1 = false;
	public bool slot2 = false;
	public bool slot3 = false;
	public bool slot4 = false;

	public GameObject N_Manager;
	public GameObject redflash;

	void Start ()
	{
		N_Manager = GameObject.Find ("Network_Manager");
		Screen.orientation = ScreenOrientation.Landscape;
    }

	void Validate () 
	{
		if (slot1 == true && slot2 == true && slot3 == true && slot4 == true) {
			GameObject.Find ("Slot1").GetComponent<Image> ().color = Color.green;
			GameObject.Find ("Slot2").GetComponent<Image> ().color = Color.green;
			GameObject.Find ("Slot3").GetComponent<Image> ().color = Color.green;
			GameObject.Find ("Slot4").GetComponent<Image> ().color = Color.green;
			N_Manager.GetComponent<SFS2X_Connect> ().BroadcastMessage ("PZ1EntranceComplete");
		} else {
			redflash.GetComponent<Animator> ().Play ("FlashRed");
		}
	}
}
