using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private int zettelCount = 2;
    Text countText;

    private void Awake()
    {
        countText = gameObject.GetComponent<Text>();
    }

    public void GetZettel()
    {

    }
        	
	
	void Update ()
    {

        countText.text = (zettelCount + " / 10");
        


	}
}
