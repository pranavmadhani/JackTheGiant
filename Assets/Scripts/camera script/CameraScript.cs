using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour

    


{
    private float speed = 1f;
    private float acceleration = 0.05f;
    private float maxSpeed = 3.2f;


    private float easySpeed = 3.2f;
    private float mediumSpeed = 3.5f;
    private float hardSpeed = 3.8f;


    [HideInInspector]
    public bool moveCamera;

    void Start()
    {
        if(prefs.GetEasyDifficulty() == 1)
        {
            maxSpeed = easySpeed;
        }

        if (prefs.GetMediumDifficulty() == 1)
        {
            maxSpeed = mediumSpeed;
        }

        if (prefs.GetHardDifficulty() == 1)
        {
            maxSpeed = hardSpeed;
        }

        moveCamera = true;

    }

   
    void Update()
    {
        if (moveCamera)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        Vector3 currentPosition = transform.position;

        float oldY = currentPosition.y;
        float newY = currentPosition.y-(speed * Time.deltaTime );
        currentPosition.y = Mathf.Clamp(currentPosition.y, oldY, newY);
        transform.position = currentPosition;
        speed += acceleration * Time.deltaTime;

        if(speed >  maxSpeed)
        {
            speed = maxSpeed;
        }

    }


}
