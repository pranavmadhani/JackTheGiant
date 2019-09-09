using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private float minX;
    private float maxX;
    private GameObject player;
    

    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint((new Vector3(Screen.width, Screen.height, 0)));
        maxX = bounds.x-0.3f ;
        minX = -bounds.x+0.3f ;





    }

    void Start()
    {

       

        SetMinAndMax();
        
    }

    // Update is called once per frame
    void Update()
    {
       
            
        if(transform.position.x < minX)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = minX;
            transform.position = currentPosition;
        }

        else if (transform.position.x > maxX)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = maxX;
            transform.position = currentPosition;
        }
    }
}
