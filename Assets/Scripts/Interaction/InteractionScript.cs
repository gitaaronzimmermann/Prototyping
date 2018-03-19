using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{

    [SerializeField] float interactionRadius = 5.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit, interactionRadius))
            {
                // Door 
                DoorInteraction doorObject = hit.collider.GetComponent<DoorInteraction>();
                if (doorObject)
                {
                    doorObject.Toggle();
                }

                // Filecabinet
                FileCabinetScript fileCabinet = hit.collider.GetComponent<FileCabinetScript>();
                if (fileCabinet)
                {
                    fileCabinet.ToggleDrawer();
                }


            }
        }
    }
}
