using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSwipe : MonoBehaviour {

    Vector2 fingerDown;
    Vector2 fingerUp;
    public bool waitForSwipe = false;
    public float swipeRange = 20f;
    Rigidbody vearb;
    public float speed; 

    public GameObject vea;

    // Use this for initialization
    void Start () {
        vearb = vea.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ////Test
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
        ///////////////////////


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
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalMove() > swipeRange && horizontalMove() > verticalMove())
        {

            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
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
        vearb.velocity = new Vector3(0, 0, -speed);
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");
        vearb.velocity = new Vector3(-speed, 0, 0);
    }

    void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
        vearb.velocity = new Vector3(speed, 0, 0);
    }

}
