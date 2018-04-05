using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSwipe : MonoBehaviour {

    Vector2 fingerDown;
    Vector2 fingerUp;
    public bool waitForSwipe = false;
    public float swipeRange = 20f;
    GameObject Camera;
    Rigidbody vearb;
    public float speed;
    float Deltax;
    float Deltay;

    public GameObject vea;

    // Use this for initialization
    void Start () {
        vearb = vea.GetComponent<Rigidbody>();
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /////////////////////////////////////////////////////////////////Test PC///////////////////////////////////////////////////////////
        if(Input.GetKey(KeyCode.UpArrow))
        {
            vearb.velocity = new Vector3(0, 0, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vearb.velocity = new Vector3(0, 0, -speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vearb.velocity = new Vector3(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vearb.velocity = new Vector3(speed, 0, 0);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!waitForSwipe)
                {
                    fingerDown = touch.position;
                    checkSwipeDir();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipeDir();
            }
        }
    }

    void checkSwipeDir()
    {
        //Check if Vertical swipe
        if (verticalMove() > swipeRange && verticalMove() > horizontalMove())
        {
            //Debug.Log("Vertical");
            Deltay = fingerDown.y - fingerUp.y;
            speed = Deltay / 25;
            if (speed > 3)
            {
                speed = 3;
            }
            if (speed < -3)
            {
                speed = -3;
            }
            if (Deltay > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (Deltay < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalMove() > swipeRange && horizontalMove() > verticalMove())
        {
            Deltax = fingerDown.x - fingerUp.x;
            speed = Deltax/25;
            if (speed > 3)
            {
                speed = 3;
            }
            if (speed < -3)
            {
                speed = -3;
            }
            if (Deltax > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (Deltax < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    void OnSwipeUp()
    {
        Debug.Log("Swipe UP");
        vearb.velocity = new Vector3(0, 0, speed);
        
    }

    void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
        vearb.velocity = new Vector3(0, 0, speed);
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");
        vearb.velocity = new Vector3(speed, 0, 0);
    }

    void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
        vearb.velocity = new Vector3(speed, 0, 0);
    }

}
