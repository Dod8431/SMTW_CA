using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Entities.Variables;
using Sfs2X.Requests;
using Sfs2X.Logging;

public class SFS2X_Connect : MonoBehaviour {

	public InputField ip_field;
	private int ServerPort = 9933;
	private string ZoneName = "BasicExamples";
	private string UserName = "";
	private string RoomName = "The Lobby";

	public bool P1_Entrance_Riddle = false;
	public bool P1_Puzzle = false;
	public bool P2_Puzzle = false;
	public bool P2_Puzzle_Minigame = false;
	public bool Maze = false;

	SmartFox sfs;

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	void Start()
	{
		sfs = new SmartFox ();
		sfs.ThreadSafeMode = true;

		sfs.AddEventListener (SFSEvent.CONNECTION, OnConnection);
		sfs.AddEventListener (SFSEvent.LOGIN, OnLogin);
		sfs.AddEventListener (SFSEvent.LOGIN_ERROR, OnLoginError);
		sfs.AddEventListener (SFSEvent.ROOM_JOIN, OnJoinRoom);
		sfs.AddEventListener (SFSEvent.ROOM_JOIN_ERROR, OnJoinRoomError);
		sfs.AddEventListener (SFSEvent.OBJECT_MESSAGE, OnObjectRequest);
	}

	public void Connect()
	{
		sfs.Connect (ip_field.text, ServerPort);
	}

	void OnLogin(BaseEvent evt)
	{
		Debug.Log ("Logged In: " + evt.Params ["user"]);
		GameObject.Find ("isConnected?").GetComponent<Text> ().color = Color.green;
		sfs.Send (new JoinRoomRequest (RoomName));
	}

	void OnJoinRoom(BaseEvent evt)
	{
		Debug.Log ("Joined Room: " + evt.Params ["room"]);
	}

	void OnJoinRoomError(BaseEvent evt)
	{
		Debug.Log ("Join Room Error (" + evt.Params ["errorCode"] + "): " + evt.Params ["errorMessage"]);
	}

	void OnLoginError(BaseEvent evt)
	{
		Debug.Log ("Login error: (" + evt.Params ["errorCode"] + "): " + evt.Params ["errorMessage"]);
	}
		
	void OnConnection(BaseEvent evt)
	{
		if ((bool)evt.Params ["success"]) {
			Debug.Log ("Successfully Connected");
			sfs.Send (new LoginRequest (UserName, "", ZoneName));
			SceneManager.LoadScene ("CA_Main_Scene");
		} else {
			Debug.Log ("Connection Failed");
		}
	}

	void Update()
	{
		sfs.ProcessEvents ();

	}

	void OnApplicationQuit()
	{
		if (sfs.IsConnected) {
			sfs.Disconnect ();
		}
	}

	void PZ1EntranceComplete()
	{
		ISFSObject pz1entrancecomplete = new SFSObject ();
		pz1entrancecomplete.PutBool ("pz1entrancecomplete", true);
		sfs.Send (new ObjectMessageRequest (pz1entrancecomplete));

	}

    public void PZ2Mazeposition(float veax, float veaz)
    {
        ISFSObject veapos = new SFSObject();
        veapos.PutFloat("px", veax);
        veapos.PutFloat("pz", veaz);
        sfs.Send(new ObjectMessageRequest(veapos));
    }

	void OnObjectRequest(BaseEvent evt)
	{
		ISFSObject P1_Entrance = (SFSObject)evt.Params ["message"];
		P1_Entrance_Riddle = P1_Entrance.GetBool ("P1_Entrance");
	}
}
