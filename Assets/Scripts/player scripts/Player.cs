using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D myBody;
    private Animator anim;
   
    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
      // playerKeyboardMovements();

    }
    


    void playerKeyboardMovements()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");//returns -1,0,1 for left no mov and right dir resp
            
        if(h > 0)
        {
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            if (vel < maxVelocity)
            {

                forceX = speed;
                anim.SetBool("walk",true);
            }
            
        }

        else if(h < 0)
        {

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            if (vel < maxVelocity)
            {
                forceX = -speed;
                anim.SetBool("walk", true);
              
                
            }

           
            
        }

        else
        {
            anim.SetBool("walk", false);
        }
        myBody.AddForce(new Vector2(forceX,0));
        


        }

    
}


