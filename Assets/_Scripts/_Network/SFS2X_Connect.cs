using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities;
using Sfs2X.Entities.Data;
using Sfs2X.Entities.Variables;
using Sfs2X.Requests;
using Sfs2X.Logging;

public class SFS2X_Connect : MonoBehaviour {

	public string ServerIP = "127.0.0.1";
	public int ServerPort = 9933;
	public string ZoneName = "BasicExamples";
	public string UserName = "";
	public string RoomName = "The Lobby";

	public bool P1_Entrance_Riddle = false;

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

		sfs.Connect (ServerIP, ServerPort);
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

	void OnObjectRequest(BaseEvent evt)
	{
		ISFSObject P1_Entrance = (SFSObject)evt.Params ["message"];
		P1_Entrance_Riddle = P1_Entrance.GetBool ("check");
	}
}
