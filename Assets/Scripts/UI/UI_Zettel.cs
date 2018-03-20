using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Zettel : MonoBehaviour {

    [SerializeField] int zettelCount = 0;    // Anzahl gesammelter Zettel
    [SerializeField] int maxZettel   = 10;   // Anzahl maximal zu findender Zettel   

    Text countText;

    private void Awake()
    {
        countText = gameObject.GetComponent<Text>();
    }
    	
	void Update ()
    {
        countText.text = (zettelCount + " / " + maxZettel);
	}

    /// <summary>
    /// Adds one Zettel to current zettelCount
    /// </summary>
    public void ZettelAdd()
    {
        zettelCount += 1;
    }    
}
