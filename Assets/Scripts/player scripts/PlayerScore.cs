using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

   void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

   
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        countScores();
    }



    void countScores()
    {
        if(countScore)
        {
            if(transform.position.y < previousPosition.y)
            {
                scoreCount++;
                
            }
            previousPosition = transform.position;
            GamePlayController.instance.setScore(scoreCount);
        }


    }

   void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="coin")
        
        {
            coinCount++;
            scoreCount += 200;

            GamePlayController.instance.setScore(scoreCount);
            GamePlayController.instance.setCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
      }

        if (target.tag == "life")
        {
            lifeCount++;
            scoreCount += 300;
            AudioSource.PlayClipAtPoint(lifeClip , transform.position);

            GamePlayController.instance.setScore(scoreCount);
            GamePlayController.instance.setLifeScore(lifeCount);

            target.gameObject.SetActive(false);
        }

        if (target.tag == "bounds")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;
            GameManager.instance.checkGameStatus(scoreCount, coinCount, lifeCount);



        }

        if (target.tag == "deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;

            GameManager.instance.checkGameStatus(scoreCount, coinCount, lifeCount);




        }


    }

}
