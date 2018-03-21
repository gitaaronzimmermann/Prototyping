using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour {



    public void ButtonTest()
    {
        SceneManager.LoadScene(1);
    }

    void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
