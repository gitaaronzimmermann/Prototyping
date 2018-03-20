using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCabinetScript_90 : MonoBehaviour
{
    [SerializeField, Range(0.01f, 5)] private float speed = 2;
    Rigidbody myRigidbody;

    [SerializeField] float moveRange = 100;
    private float movedRange;
    private float moving;

    private float startPosZ;
    private float endPosZ;

    [SerializeField] float openRange = 5;

    private bool isOpen = false;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();

        startPosZ = transform.position.z;
        endPosZ = transform.position.z - 0.425f;

        isOpen = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ToggleDrawer();
            Debug.Log("Mouse");
        }
    }

    public void ToggleDrawer()
    {

        moving = transform.position.z;

        // Closing
        if (isOpen)
        {
            while (moving <= startPosZ)
            {
                myRigidbody.velocity = transform.forward * speed;
                moving = transform.position.z;

                //myRigidbody.velocity = -transform.forward * speed;
                //movedRange += transform.position.x;
            }

            Debug.Log("Closing");
            myRigidbody.velocity = Vector3.zero;
            isOpen = !isOpen;
        }

        // Opening
        if (!isOpen)
        {
            while (moving > endPosZ)
            {
                myRigidbody.velocity = -transform.forward * speed;
                moving = transform.position.z;
            }

            Debug.Log("Opening");
            myRigidbody.velocity = Vector3.zero;
            isOpen = !isOpen;
        }

    }

}
