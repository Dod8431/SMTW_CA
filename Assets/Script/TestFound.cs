using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestFound : MonoBehaviour {

    public SFS2X_Connect sfs;
    public GameController gc;
    public Animator japanend;
    public Animator vea;
    private bool check;

    void Start()
    {
        sfs = GameObject.Find("Network_Manager").GetComponent<SFS2X_Connect>();
        gc = GameObject.Find("CA_Manager").GetComponent<GameController>();
    }
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Vea") {
            sfs.Maze_End();
            StartCoroutine(End());
		}
	}

    IEnumerator End()
    {
        Camera.main.GetComponent<CameraControllerMiniGame>().enabled = false;
        vea.Play("VeaMazeEnd");
        yield return new WaitForSeconds(3);
        japanend.Play("JapanEnd");
        yield return new WaitForSeconds(9);
        gc.Reboot();
        sfs.Reboot();
        SceneManager.LoadScene(1);
    }
}
