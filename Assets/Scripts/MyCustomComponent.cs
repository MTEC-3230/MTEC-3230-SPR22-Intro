using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCustomComponent : MonoBehaviour
{



    


    private void Start()
    {
        // DebugExample();

    }



    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed!"); 
            
        }


    }


    void DebugExample()
    {


        //print("Hello World!");


        Debug.Log("This is a normal log message.");
        Debug.LogWarning("This is a warning message.");
        Debug.LogError("This is an Error message.");




    }


}
