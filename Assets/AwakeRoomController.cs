using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AwakeRoomController : MonoBehaviour {

	public GameObject markglow;
	public GameObject background;
	public SFS2X_Connect network;
	public GameObject doorright;
	public GameObject doorleft;
	public GameObject dooropen;
	public GameObject doorbutton;

	// Use this for initialization
	void Start () {
		network = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (network.markglow == true) {
			StartCoroutine (ShakeAndGlow ());
			StartCoroutine (Vibrate ());
			network.markglow = false;
		}
	}

	public void DoorOpen()
	{
		doorright.GetComponentInParent<Animator> ().Play ("AwakeRoom_OpenDoor");
		network.BroadcastMessage ("AwakeRoomOpenDoor");
		StartCoroutine (OpenAndLeave ());
	}

	IEnumerator ShakeAndGlow()
	{
		markglow.SetActive (true);
		yield return new WaitForSeconds (4);
		markglow.SetActive (false);
		doorbutton.SetActive (true);
		doorright.SetActive (true);
		doorleft.SetActive (true);
		dooropen.SetActive (true);
	}

	IEnumerator OpenAndLeave()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("CA_Main_Scene");

	}

	IEnumerator Vibrate()
	{
		for (int i = 0; i < 33; i++) {
			Handheld.Vibrate ();
			yield return new WaitForSeconds (0.15f);
		}
	}
}
