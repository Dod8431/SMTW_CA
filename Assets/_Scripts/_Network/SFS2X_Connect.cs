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
    public bool MainScene = false;
    public bool Narrative = false;

    public bool P2_M1 = false;
    public bool P2_M2 = false;
    public bool P2_M3 = false;
    public bool P2_M4 = false;

    public bool markglow = false;
    public int sceneIndex;
    public int narrativeIndex;

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
            SceneManager.LoadScene(1);
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
		
	void AwakeRoomOpenDoor()
	{
		ISFSObject awakeroomopendoor = new SFSObject ();
		awakeroomopendoor.PutBool ("awakeroomopendoor", true);
		sfs.Send(new ObjectMessageRequest (awakeroomopendoor));
	}

    public void PZ2Mazeposition(float veax, float veaz)
    {
        ISFSObject veapos = new SFSObject();
        veapos.PutFloat("PZ2Mazex", veax);
        veapos.PutFloat("PZ2Mazez", veaz);
        sfs.Send(new ObjectMessageRequest(veapos));
    }

	void Narrative_End()
	{
		ISFSObject narrative_end = new SFSObject ();
		narrative_end.PutBool ("narrativeend", true);
		sfs.Send (new ObjectMessageRequest (narrative_end));
	}


	void OnObjectRequest(BaseEvent evt)
	{
        ISFSObject P1_Entrance_RiddlePC = (SFSObject)evt.Params["message"];
        ISFSObject P1_PuzzlePC = (SFSObject)evt.Params["message"];
        ISFSObject P2_PuzzlePC = (SFSObject)evt.Params["message"];
        ISFSObject P2_Puzzle_MinigamePC = (SFSObject)evt.Params["message"];
        ISFSObject MazePC = (SFSObject)evt.Params ["message"];
        ISFSObject MainScenePC = (SFSObject)evt.Params["message"];
		ISFSObject MarkGlowActive = (SFSObject)evt.Params ["message"];
        ISFSObject indexScene = (SFSObject)evt.Params["message"];
        ISFSObject narrativeIndexPC = (SFSObject)evt.Params["message"];
        ISFSObject NarrativePC = (SFSObject)evt.Params["message"];
		ISFSObject ButtonP2PC = (SFSObject)evt.Params ["message"];
		P2_M1 = ButtonP2PC.GetBool ("1");
		P2_M2 = ButtonP2PC.GetBool ("2");
		P2_M3 = ButtonP2PC.GetBool ("3");
		P2_M4 = ButtonP2PC.GetBool ("4");
        Narrative = NarrativePC.GetBool("Narrative");
        narrativeIndex = narrativeIndexPC.GetInt("narrativeIndex");
        sceneIndex = indexScene.GetInt("sceneIndex");
		markglow = MarkGlowActive.GetBool ("markglow");
        P1_Entrance_Riddle = P1_Entrance_RiddlePC.GetBool("P1_Entrance");
        P1_Puzzle = P1_PuzzlePC.GetBool("P1_Puzzle");
        P2_Puzzle = P2_PuzzlePC.GetBool("P2_Puzzle");
        P2_Puzzle_Minigame = P2_Puzzle_MinigamePC.GetBool("P2_Puzzle_Minigame");
        Maze = MazePC.GetBool("Maze");
        MainScene = MainScenePC.GetBool("MainScene");
    }
}
