using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFound : MonoBehaviour {

    public SFS2X_Connect sfs;

    void Start()
    {
        sfs = GameObject.Find("Network_Manager").GetComponent<SFS2X_Connect>();
    }
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Vea") {
            Debug.Log("cc");
            sfs.Maze_End();
            Destroy(other);
		}
	}
}
