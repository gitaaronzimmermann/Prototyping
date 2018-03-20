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
    public Renderer rend;


    int key = 0;

    #endregion

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Outlined/Silhouette Only");
                    rend.material.SetFloat("_width", 0.03f);        
    }


    void Update()
    {
        RaycastHit hitInfo;
        Renderer currRenderer;
        Renderer rend;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // highlights gameObject if its a collectible and in range of raycast
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, distanceToSee) && hitInfo.transform.tag == "collectible")
        {

            // collect object and delete it from scene, adding +1 to inventory
            if (Input.GetKey(KeyCode.E))
            {
                key += 1;
                Debug.Log(key);
                Destroy(hitInfo.collider.gameObject);
            }

            
        }
    }
            /*
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
    //*/
}
