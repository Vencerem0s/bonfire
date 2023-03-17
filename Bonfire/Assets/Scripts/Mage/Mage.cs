using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Q key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            print("E key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            print("F key was pressed");
        }
    }
}
