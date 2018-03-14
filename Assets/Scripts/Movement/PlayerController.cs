using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Var's
    public float moveSpeed = 10f;  // Player Movement Speed
    public float rotateSpeed = 100f; // Camera Rotation Speed

    public float CameraFOV = 75.0f;  // Camera Field of View
    #endregion

    void Update()
    {

        // Sprint
        #region Sprint   
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // higher move speed while running
            moveSpeed = 20f;

            // Highers the Camera Field of view while sprinting
            if (CameraFOV < 75f)
            {
                CameraFOV *= 1.01f; // Smooth transition
            }
            if (CameraFOV >= 75)
            {
                CameraFOV = 75;
            }
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            // normal move speed
            moveSpeed = 10f;

            // Lowers the Camera FOV back to normal when not sprinting
            if (CameraFOV > 60f)
            {
                CameraFOV *= 0.99f; // Smooth transition
            }
            if (CameraFOV <= 60)
            {
                CameraFOV = 60;
            }
        }

        Camera.main.fieldOfView = CameraFOV;

        #endregion


        // Controller
        #region Controller

        // Keyboard Input - WASD
        float xInputTranslate = Input.GetAxis("Horizontal");
        float zInputTranslate = Input.GetAxis("Vertical");

        // Mouse Input
        float xMouseInput = Input.GetAxis("Mouse X") * rotateSpeed;

        // Movement        
        transform.localPosition += transform.forward * zInputTranslate * moveSpeed * Time.deltaTime
                                + transform.right * xInputTranslate * moveSpeed * Time.deltaTime;

        // Rotation
        transform.Rotate(0.0f, xMouseInput, 0.0f);

        #endregion

    }
}
