using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D myBody;
    private Animator anim;

    private bool moveLeft, moveRight;

    void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        Vector3 temp = transform.localScale;
        temp.x = -1.3f;
        transform.localScale = temp;

        if (vel < maxVelocity)
         forceX = -speed;

            anim.SetBool("walk", true);
            myBody.AddForce(new Vector2(forceX, 0));
        
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        Vector3 temp = transform.localScale;
        temp.x = 1.3f;
        transform.localScale = temp;

        if (vel < maxVelocity)
        forceX = speed;

            anim.SetBool("walk", true);
            myBody.AddForce(new Vector2(forceX, 0));
        
    }


    public void SetMoveLeft(bool move)
    {
        this.moveLeft = move;
        this.moveRight = !move;

    }

   


    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("walk", false);
    }

    void FixedUpdate()
    {
        if(moveLeft)
        {
            MoveLeft();
        }
        if(moveRight)
        {
            MoveRight();
        }

        
    }

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }






}
