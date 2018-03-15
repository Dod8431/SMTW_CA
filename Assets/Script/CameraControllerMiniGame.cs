using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMiniGame : MonoBehaviour {

   // public GameObject vea;
    public float speed;
    private Vector3 veapos;
    bool exit = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(exit)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, veapos, speed * Time.deltaTime);
            if (this.transform.position == veapos)
            {
                exit = false;
            }
        }
	}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Vea"))
        {
            veapos = new Vector3 (other.transform.position.x,2, other.transform.position.z);
            exit = true;
        }
    }
}
