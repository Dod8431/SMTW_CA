using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask_Controller : MonoBehaviour {

    public float speed = 0.06f;
    private bool check = false;

    public float boundX = 950;
    public float boundY = 1700;
    public float correctionZ;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update ()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, -boundX, boundX),
            Mathf.Clamp(transform.position.y, -boundY, boundY),
            correctionZ
        );

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(1, 0, 0) * speed;
        }

        

        if (Input.touchCount >0 && check == false)
        {
            GetComponent<Animator>().Play("TorchOpen");
            check = true;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            this.transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
        }
    }
}
