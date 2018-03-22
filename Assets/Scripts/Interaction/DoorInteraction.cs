using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{

    [SerializeField] bool isDoorOpen = false;

    private float closedDoor;
    private float openDoor;

    [SerializeField] float doorAngel = 90f;

    float doorRotation;

    // Sounds

    [SerializeField] float volume = 0.5f;
    private bool ongoingSound = false;

    public AudioClip doorOpen;
    public AudioClip doorClose;

    private AudioSource source;



    private void Awake()
    {
        closedDoor = transform.rotation.x;
        openDoor = closedDoor - doorAngel;

        source = GetComponent<AudioSource>();
    }

    public void Toggle()
    {
       isDoorOpen = !isDoorOpen;                // Change status
    }
    
    private void Update()
    {
        if (isDoorOpen)
        {
            if (!ongoingSound)
            {
                source.PlayOneShot(doorClose, volume);
                ongoingSound = true;
            }

            if (doorRotation < openDoor)
            {
                doorRotation *= 1.05f;          // Smooth open
            }

            if (doorRotation >= openDoor)
            {
                doorRotation = openDoor;
                ongoingSound = false;
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
