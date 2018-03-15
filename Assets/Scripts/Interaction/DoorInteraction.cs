using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{

    private bool isDoorOpen = false;

    [SerializeField] float closedDoor = 1f;
    [SerializeField] float openDoor   = 90f;
    float doorRotation;

    
    public void Toggle()
    {
       isDoorOpen = !isDoorOpen;                // Check if door is open
    }
    
    private void Update()
    {
        if (isDoorOpen)
        {
            if (doorRotation < openDoor)
            {
                doorRotation *= 1.05f;          // Smooth open
            }

            if (doorRotation >= openDoor)
            {
                doorRotation = openDoor;
            }
        }

        if (!isDoorOpen)
        {
            if (doorRotation > closedDoor)
            {
                doorRotation *= 0.95f;          // Smooth Close
            }

            if (doorRotation <= closedDoor)
            {
                doorRotation = closedDoor;
            }
        }

        transform.rotation = Quaternion.Euler(0f, doorRotation, 0f);
    }


}
