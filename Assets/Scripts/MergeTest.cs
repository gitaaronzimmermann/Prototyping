using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeTest : MonoBehaviour
{
    #region Var's Interaction Script
    [SerializeField] float interactionRadius = 5.0f;
    #endregion

    #region Var's Highlighting
    public float distanceToSee;
    public string ObjectName;
    private Color highlightColor;
    Material originalMaterial, tempMaterial;
    Renderer renderer = null;
    int key = 0;
    int collectible = 0;
    bool safeKey = false;
    Light light;
    public GameObject l;
    UI_Key trash;
    #endregion

    void Start()
    {
        highlightColor = Color.green;
        l = GameObject.Find("Light");
        Test light = GetComponent<Test>();
        UI_Key trash = GetComponent<UI_Key>();
    }

    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Renderer currRenderer;

        #region Highlight Object
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, distanceToSee))
        {

            #region InteractionScript
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
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
                        keyObject.KeyAdd();
                    }

                }
            }
            #endregion


            if (hitInfo.transform.tag == "collectible" || hitInfo.transform.tag == "key")
            {
                // collect object and delete it from scene, adding +1 to inventory
                if (Input.GetKey(KeyCode.E))
                {
                    if (hitInfo.transform.tag == "key")
                    {
                        trash.KeyAdd();
                        key += 1;
                        Debug.LogFormat("Keys: {0} ", key);
                    }
                    if (hitInfo.transform.tag == "collectible")
                    {
                        collectible += 1;
                        Debug.LogFormat("collectibles: {0} ", collectible);
                    }
                    Destroy(hitInfo.collider.gameObject);
                }
                currRenderer = hitInfo.collider.gameObject.GetComponent<Renderer>();

                if (currRenderer == renderer)
                    return;

                if (currRenderer && currRenderer != renderer)
                {
                    if (renderer)
                    {
                        renderer.sharedMaterial = originalMaterial;
                    }

                }

                if (currRenderer)
                    renderer = currRenderer;
                else
                    return;

                originalMaterial = renderer.sharedMaterial;

                tempMaterial = new Material(originalMaterial);
                renderer.material = tempMaterial;
                renderer.material.color = highlightColor;
            }
            else
            {
                if (renderer)
                {
                    renderer.sharedMaterial = originalMaterial;
                    renderer = null;
                }
            }
        }
        #endregion



    }
}
