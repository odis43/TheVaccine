using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extendground : MonoBehaviour
{
   
   

    private Vector3 scalechange;

    float differenceLeft;
    float differenceRight;
    void Awake()
    {
        
        scalechange = new Vector3(1f, 0f, 0f);
        transform.GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {

        differenceLeft = Vector3.Distance(GameObject.FindGameObjectWithTag("VertexLeft").transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        differenceRight = Vector3.Distance(GameObject.FindGameObjectWithTag("VertexRight").transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (differenceLeft<=3f)
        {
            for(int i = 0; i < 2f; i++)
            {
                transform.localScale += scalechange;
            }

        }

        if (differenceRight <= 3f)
        {
            for (int i = 0; i < 2f; i++)
            {
                transform.localScale += scalechange;
            }

        }


    }
}
