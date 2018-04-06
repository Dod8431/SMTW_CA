using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ2MiniGameController : MonoBehaviour {

    public SFS2X_Connect sfs;
    public Transform vea;

    void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        sfs = GameObject.Find("Network_Manager").GetComponent<SFS2X_Connect>();
        vea = GameObject.Find("Vea_Orb").transform;

    }
	
	
	void Update ()
    {
        sfs.PZ2Mazeposition(vea.position.x, vea.position.z);
    }
}
