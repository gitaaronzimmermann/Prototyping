using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInteraction : MonoBehaviour
{
    private bool drawerOpen = false;

    Rigidbody myRigidbody;
    [SerializeField] float speed = 10f;
    [SerializeField] float openLength = 1f;
    
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();        
    }

    public void ToggleDrawer()
    {
        if (drawerOpen)
        {
            for (int i = 1; i < openLength; i++)
            {
                myRigidbody.position = transform.forward * speed; 
            }

           // myRigidbody.velocity = transform.forward * 0f;
            drawerOpen = (!drawerOpen);

        }

        if (!drawerOpen)
        {
            for (int i = 1; i < openLength; i++)
            {
                myRigidbody.velocity= -transform.forward * speed;
            }

          //  myRigidbody.velocity = transform.forward * 0f;
            drawerOpen = (!drawerOpen);

        }
    }


}
