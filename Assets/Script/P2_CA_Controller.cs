using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_CA_Controller : MonoBehaviour {
    public SFS2X_Connect network;
    
	public bool button1;
	public bool button2;
	public bool button3;
	public bool button4;

	public GameObject symbol1;
	public GameObject symbol2;
	public GameObject symbol3;
	public GameObject symbol4;

    void Start () {
        network = GameObject.Find("Network_Manager").GetComponent<SFS2X_Connect>();
    }

	void Update () 
	{
		button1 = network.P2_M1;
		button2 = network.P2_M2;
		button3 = network.P2_M3;
		button4 = network.P2_M4;

		if (button1 == true) {
			symbol1.GetComponent<Animator> ().Play ("Symbol_On");
		} else {
			symbol1.GetComponent<Animator> ().Play ("Symbol_Off");
		}

		if (button2 == true) {
			symbol2.GetComponent<Animator> ().Play ("Symbol_On");
		} else {
			symbol2.GetComponent<Animator> ().Play ("Symbol_Off");
		}

		if (button3 == true) {
			symbol3.GetComponent<Animator> ().Play ("Symbol_On");
		} else {
			symbol3.GetComponent<Animator> ().Play ("Symbol_Off");
		}

		if (button4 == true) {
			symbol4.GetComponent<Animator> ().Play ("Symbol_On");
		} else {
			symbol4.GetComponent<Animator> ().Play ("Symbol_Off");
		}
	}
}
