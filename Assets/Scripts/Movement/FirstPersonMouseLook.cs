using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class FirstPersonMouseLook : MonoBehaviour
{


    public float lookSensitivity = 5f;

    public float xRotation;

    public float yRotation;

    public float currentXRotation;

    public float currentYRotation;

    public float xRotaionV;

    public float yRotationV;

    public float lookSmothDamp = 0.1f;




    void Start()
    {

    }


    // Update is called once per frame

    void Update()
    {


        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;


        xRotation = Mathf.Clamp(xRotation, -45, 45);


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);


    }

}
