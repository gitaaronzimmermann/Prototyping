using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Light light;
    public GameObject l;

	// Use this for initialization
	void Start () {
        l = GameObject.Find("Light");
        light = l.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)){
            light.intensity = 0f;
        }
        
	}

    public void SetLight(float value)
    {
        light.intensity = value;
    }

}
