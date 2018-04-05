using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene_Controller : MonoBehaviour {

    public int state;
    public GameObject cross1;
    public GameObject cross2;
    public GameObject cross3;
    public GameObject cross4;
    public GameObject cross5;
    GameObject vea;
    float speed;

    void Start()
    {
        vea = GameObject.Find("Vea");
        speed = 20 * Time.deltaTime;
        Screen.orientation = ScreenOrientation.Portrait;
    }


    // Update is called once per frame
    void Update () {
        state = GameObject.Find("CA_Manager").GetComponent<GameController>().progress;
        if (state == 0)
        {
            vea.transform.Rotate(Vector3.forward, 3 * speed);
        }
		if (state == 1)
        {
            RotateVea(cross1, cross2);
        }
        if (state == 2)
        {
            cross1.SetActive(true);
            RotateVea(cross2, cross3);
        }
        if (state == 3)
        {
            cross1.SetActive(true);
            cross2.SetActive(true);
            RotateVea(cross3, cross4);
        }
        if (state == 4)
        {
            cross1.SetActive(true);
            cross2.SetActive(true);
            cross3.SetActive(true);
            RotateVea(cross4, cross5);
        }
        if (state == 5)
        {
            cross1.SetActive(true);
            cross2.SetActive(true);
            cross3.SetActive(true);
            cross4.SetActive(true);
            cross5.SetActive(true);

        }
    }

     void RotateVea(GameObject cross, GameObject next)
     {
        cross.SetActive(true);
        vea.transform.position = Vector3.MoveTowards(vea.transform.position, next.transform.position, speed);
        vea.transform.Rotate(Vector3.forward, 3*speed);
     }

}
