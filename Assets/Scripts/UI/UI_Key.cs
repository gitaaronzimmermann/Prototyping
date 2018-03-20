using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Key : MonoBehaviour {

    [SerializeField] int keyCount = 0;    // Anzahl gesammelter keys
    [SerializeField] int maxkeys  = 10;   // Anzahl maximal zu findender keys   

    Text countText;

    private void Awake()
    {
        countText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        countText.text = (keyCount + " / " + maxkeys);
    }

    /// <summary>
    /// Adds one Zettel to current zettelCount
    /// </summary>
    public void ZettelAdd()
    {
        keyCount += 1;
    }
}
