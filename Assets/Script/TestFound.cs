using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFound : MonoBehaviour {

    public SFS2X_Connect sfs;
    private bool check;

    void Start()
    {
        sfs = GameObject.Find("Network_Manager").GetComponent<SFS2X_Connect>();
    }
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Vea") {
            sfs.Maze_End();
		}
	}
}
