using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AwakeRoomController : MonoBehaviour {

	public GameObject markglow;
	public GameObject background;
	public SFS2X_Connect network;
    public GameObject doorpanel;

	// Use this for initialization
	void Start () {
		network = GameObject.Find ("Network_Manager").GetComponent<SFS2X_Connect> ();
        Screen.orientation = ScreenOrientation.Portrait;
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
		doorpanel.GetComponent<Animator> ().Play ("Awake_Room_OpenDoor");
        for (int i = 0; i < 6; i++)
        {
            Handheld.Vibrate();
        }
		network.BroadcastMessage ("AwakeRoomOpenDoor");
		StartCoroutine (OpenAndLeave ());
	}

	IEnumerator ShakeAndGlow()
	{
		markglow.SetActive (true);
		yield return new WaitForSeconds (4);
		markglow.SetActive (false);
        doorpanel.SetActive(true);
	}

	IEnumerator OpenAndLeave()
	{
		yield return new WaitForSeconds (5);
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
