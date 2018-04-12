using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public bool reboot;
	public SFS2X_Connect sfs;
	void Start () {
		sfs = GameObject.Find("Network_Manager").GetComponent<SFS2X_Connect>();
	}
	
	public void RebootButton(int index)
	{
		if(reboot == true)
		{
			sfs.Reboot();
			SceneManager.LoadScene(index);
		} else {
			SceneManager.LoadScene(index);
		}
		
	}
}
