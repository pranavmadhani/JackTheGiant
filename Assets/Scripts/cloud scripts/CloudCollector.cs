using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="cloud" || target.tag=="deadly")
        {
            target.gameObject.SetActive(false);

        }
        
    }
}
