using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Var's

    private float moveSpeed = 0.0f;
    [SerializeField] float moveSpeedCrouching   = 2f;   // Player Crouching Speed
    [SerializeField] float moveSpeedWalking     = 3f;   // Player Walking Speed
    [SerializeField] float moveSpeedRunning     = 4f;   // Player Running Speed
    [SerializeField] float rotateSpeed          = 2.5f; // Camera Rotation Speed

    private bool crouching  = false;                    // Is player crouching? = True
    private bool running    = false;                    // Is player running? = True

    private float CameraFOV = 75.0f;                    // Camera Field of View
    private float CameraYNormal = -0.5f;                // Camera Height while standing
    private float CameraYCrouch = -1.0f;                // Camera Height while crouching
    private float CameraY;

    #endregion
     
    void Update()
    {

        // Sprint
        #region Sprint   

        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (!crouching)
            {

                // Player is now running
                running = true;

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
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {

            // Player not longer running
            running = false;

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

        // Crouch
        #region Crouch

        if (Input.GetKey(KeyCode.LeftControl))
        {

            // You can't crouch while running
            if (running)
            {
                return;
            }

            if (!running)
            {
                // Player is now crouching
                crouching = true;

                if (CameraY > CameraYCrouch)
                {
                    CameraY *= 1.05f;
                }

                if (CameraY <= CameraYCrouch)
                {
                    CameraY = CameraYCrouch;
                }
            }
        }

        if (!Input.GetKey(KeyCode.LeftControl))
        {

            crouching = false;

            if (CameraY < CameraYNormal)
            {
                CameraY *= 0.95f;
            }

            if (CameraY >= CameraYNormal)
            {
                CameraY = CameraYNormal;
            }
        }

        transform.position = new Vector3(transform.position.x, CameraY, transform.position.z);

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
