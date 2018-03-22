using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{    
    public bool safeKey = false;

    [SerializeField] float interactionRadius = 5.0f;

    void Update()
    {
        Debug.Log(safeKey);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit, interactionRadius))
            {
                DoorInteraction doorObject = hit.collider.GetComponent<DoorInteraction>();
                if (doorObject)
                {
                    if (doorObject.tag == "safe")
                    {
                        if (safeKey)
                        {
                            doorObject.Toggle();
                        }  
                    }
                    if (doorObject.tag != "safe")
                    {
                        doorObject.Toggle();
                    }                         
                }

                // File Cabinet Interaction
                FileCabinetScript fileCabinet = hit.collider.GetComponent<FileCabinetScript>();
                if (fileCabinet)
                {
                    fileCabinet.ToggleDrawer();
                }

                // drawer interaction
                DrawerInteraction drawerObject = hit.collider.GetComponent<DrawerInteraction>();
                if (drawerObject)
                {
                    drawerObject.ToggleDrawer();
                }

                // Keyobject interaction
                UI_Key keyObject = hit.collider.GetComponent<UI_Key>();
                if (keyObject)
                {
                    safeKey = true;
                }

                DrawerInteractionHenry drawerObjectHenry = hit.collider.GetComponent<DrawerInteractionHenry>();
                if (drawerObjectHenry)
                {
                    drawerObjectHenry.ToggleDrawer();
                }

            }
        }
    }
}
