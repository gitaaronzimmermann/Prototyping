using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Var's
    private float moveSpeed = 0.0f;
    [SerializeField] float moveSpeedWalking = 2f;   // Player Walking Speed
    [SerializeField] float moveSpeedRunning = 4f;   // Player Running Speed
    [SerializeField] float rotateSpeed = 2.5f;        // Camera Rotation Speed

    public float CameraFOV = 75.0f;                 // Camera Field of View
    #endregion

    void Update()
    {

        // Sprint
        #region Sprint   

        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            if (Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical") != 0))
            {
                // higher move speed while running
                moveSpeed = moveSpeedRunning;


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

            if (Input.GetAxis("Horizontal") == 0 && (Input.GetAxis("Vertical") == 0))
            {

                // normal move speed
                moveSpeed = moveSpeedWalking;

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
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            // normal move speed
            moveSpeed = moveSpeedWalking;

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
