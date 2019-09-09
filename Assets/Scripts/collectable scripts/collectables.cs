using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectables : MonoBehaviour
{

    void destroyCollectable()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Invoke("destroyCollectable", 6f);
        
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
