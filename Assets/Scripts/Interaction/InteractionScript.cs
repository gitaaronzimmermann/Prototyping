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
                    doorObject.Toggle();
                }

                FileCabinetScript fileCabinet = hit.collider.GetComponent<FileCabinetScript>();
                if (fileCabinet)
                {
                    fileCabinet.ToggleDrawer();
                }

                DrawerInteraction drawerObject = hit.collider.GetComponent<DrawerInteraction>();
                if (drawerObject)
                {
                    drawerObject.ToggleDrawer();
                }

                
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
