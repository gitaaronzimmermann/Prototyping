using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Key : MonoBehaviour {

    public int keyCount = 0;    // Anzahl gesammelter keys
    [SerializeField] int maxkeys  = 10;   // Anzahl maximal zu findender keys   
    public int keeey;
    HighlightObject counter;
    GameObject highlight;
    Text countText;
    InteractionScript interaction;

    private void Awake()
    {
        countText = gameObject.GetComponent<Text>();
        highlight = GameObject.Find("Player");
        counter = highlight.GetComponent<HighlightObject>();

    }

    void Update()
    {
        interaction = GetComponent<InteractionScript>();
        if(interaction.safeKey == true)
        {
            Debug.Log("got a key");
            counter.key = 1;
        }
    //    countText.text = counter.key.ToString();
        countText.text = keyCount.ToString();
        
        
    }

    /// <summary>
    /// Adds one Zettel to current zettelCount
    /// </summary>
    public void KeyAdd()
    {
        keyCount += 1;
    }
}
