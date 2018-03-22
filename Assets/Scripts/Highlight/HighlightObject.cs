
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{

    #region Var's
    public float distanceToSee;
    public string ObjectName;
    private Color highlightColor;
    Material originalMaterial, tempMaterial;
    Renderer renderer = null;
    public int key = 0;
    int collectable = 0;
    bool safeKey = false;
    Light light;
    public GameObject l;
    UI_Key trash;

    bool keyForSafe = false;

    #endregion

    void Start()
    {
        highlightColor = Color.green;
        l = GameObject.Find("Light");
        Test light = GetComponent<Test>();
        UI_Key trash = GetComponent<UI_Key>();
    }


    void OnGUI()
    {
        if (Input.GetKey(KeyCode.N))
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
        }
    }

    void Update()
    {
        //Debug.Log(keyForSafe);
        Debug.Log(key);
        RaycastHit hitInfo;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Renderer currRenderer;

        if(Input.GetKey(KeyCode.G))
        {
            key += 1;
        }

        UI_Key keys = GetComponent<UI_Key>();
        if(Input.GetKey(KeyCode.P))
        {
            keys.keyCount += 1;            
        }

        // highlights gameObject if its a collectible and in range of raycast
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, distanceToSee))
        {
            if(keyForSafe == true && hitInfo.transform.tag == "safe")
            {
                // open safe
            }
            if (hitInfo.transform.tag == "collectible" || hitInfo.transform.tag == "key")
            {
                // collect object and delete it from scene, adding +1 to inventory
                if (Input.GetKey(KeyCode.E))
                {
                    if (hitInfo.transform.tag == "key")
                    {
                        InteractionScript tresor = GetComponent<InteractionScript>();
                        tresor.safeKey = true;
                        keyForSafe = true;
                        Debug.LogFormat("Keys: {0} ", key);
                    }

                    if (hitInfo.transform.tag == "collectible")
                    {
                        collectable += 1;
                        key += 1;
                        Debug.LogFormat("collectibles: {0} ", collectable);
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
    }

    public bool GetKeyBool()
    {
        return keyForSafe;
    }

}