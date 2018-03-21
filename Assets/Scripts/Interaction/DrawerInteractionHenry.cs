using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInteractionHenry : MonoBehaviour
{

    Rigidbody myRigidbody;

    public float speed = 1;

    public float maxRange = 6;
    private float moving = 0;

    private bool toggledOn;
    private bool toggledOff;
    private bool stopCounting;

    private bool running = false;
    private bool runningintern = false;

    private bool toggleHold = false;

    Vector3 startPos;

    private bool revert = false;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            if (!revert)
            {
                if (runningintern)
                {
                    myRigidbody.velocity = transform.forward * speed;
                    toggledOn = true;
                    stopCounting = true;
                    runningintern = false;
                    moving = 0;
                }


                if (toggledOn)
                {
                    if (stopCounting)
                    {
                        moving += 1;
                    }
                    if (moving == maxRange)
                    {
                        myRigidbody.velocity = transform.forward * 0;
                        stopCounting = false;
                        revert = true;
                        running = false;
                        toggleHold = false;
                    }
                }
            }

            if (revert)
            {
                {
                    if (runningintern)
                    {
                        myRigidbody.velocity = transform.forward * speed * (-1);
                        toggledOff = true;
                        stopCounting = true;
                        runningintern = false;                                           
                    }

                    if (toggledOff)
                    {
                        if (stopCounting)
                        {
                            moving -= 1;
                        }
                        if (moving == 1)
                        {
                            myRigidbody.velocity = transform.forward * 0;
                            stopCounting = false;
                            revert = false;
                            running = false;
                            this.transform.position = startPos;
                            toggleHold = false;
                        }
                    }
                }

                Debug.LogFormat("MaxRange {0}, Moving {1} ", maxRange, moving);

            }
        }
    }

    public void ToggleDrawer()
    {
        if (!toggleHold)
        {
            running = true;
            runningintern = true;
            toggleHold = true;
        }
    }
}
