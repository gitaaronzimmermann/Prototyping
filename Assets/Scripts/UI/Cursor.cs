using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    /// <summary>
    /// Keeps the MouseCursor centered and hided.
    /// Enable cursor by holding Escape.
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Screen.lockCursor = false;
        else
            Screen.lockCursor = true;
    }
}
