using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bill : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {

       
        FindObjectOfType<audiomanager>().Play("Synth");
       
    }

}
