using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Key : MonoBehaviour {

    public int keyCount = 5;    // Anzahl gesammelter keys
    [SerializeField] int maxkeys  = 10;   // Anzahl maximal zu findender keys   
    public int keeey;
    HighlightObject counter;
    GameObject highlight;
    Text countText;

    private void Awake()
    {
        countText = gameObject.GetComponent<Text>();
        highlight = GameObject.Find("Player");
        counter = highlight.GetComponent<HighlightObject>();
    }

    void Update()
    {

        countText.text = counter.key.ToString();
        
    }

    /// <summary>
    /// Adds one Zettel to current zettelCount
    /// </summary>
    public void KeyAdd()
    {
        keyCount += 1;
    }
}
