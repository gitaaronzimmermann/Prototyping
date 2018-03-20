using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCabinetScript : MonoBehaviour {

    #region Var's
    private bool isDrawerOpen = false;

    private float drawerX;
    private float drawerY;
    private float drawerZ;

    private float closedDrawer;
    private float openDrawer;
    [SerializeField] float openRange = 0.52f;
#endregion

    private void Awake()
    {
        // Gets X,Y,Z Coordinates when starting
        drawerX = transform.position.x;     
        drawerY = transform.position.y;
        drawerZ = transform.position.z;

        closedDrawer = transform.position.z;                 // Defining closed drawer position
        openDrawer   = transform.position.z - openRange;     // Defining open drawer position           
    }
    
    /// <summary>
    /// Toggles drawer state
    /// </summary>
    public void ToggleDrawer()
    {
        isDrawerOpen = !isDrawerOpen;       
    }


    /// <summary>
    /// Checks drawer state and regulates its position
    /// </summary>
    private void Update ()
    {
        if (isDrawerOpen)
        {            
            if (drawerZ > openDrawer)
            {
                drawerZ *= 0.99f;           // Open smooth
            }

            if (drawerZ <= openDrawer)
            {
                drawerZ = openDrawer;
            }
            
        }

        if (!isDrawerOpen)
        {            
            if (drawerZ < closedDrawer)
            {
                drawerZ *= 1.01f;           // Close smooth
            }

            if (drawerZ >= closedDrawer)
            {
                drawerZ = closedDrawer;
            }           
        }

        transform.position = new Vector3(drawerX, drawerY, drawerZ);
    }
}
