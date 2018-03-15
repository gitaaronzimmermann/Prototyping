using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCabinetInteraction : MonoBehaviour {

    Animator animator;

    public bool open = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (open == false)
        {
            Open();
        }

        if (open == true)
        {
            Close();
        }        
    }
    
    private void Open()
    {
        animator.SetBool("FileCabinetOpen", true);        
    }

    private void Close()
    {
        animator.SetBool("FileCabinetOpen", false);        
    }  

}
