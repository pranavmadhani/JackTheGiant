using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;

    [SerializeField]

    private GameObject[] collectables;
    private GameObject player;


    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.9f;
        minX = -bounds.x + 0.9f;



    }



    void ShuffleClouds(GameObject[] clouds)
    {
        for (int i = 0; i < clouds.Length; i++)
        {
            GameObject temp = clouds[i];
            int random = Random.Range(i, clouds.Length);
            clouds[i] = clouds[random];
            clouds[random] = temp;

        }



    }

    void CreateClouds()
    {

        ShuffleClouds(clouds);
        float positionY = 0.0f;

        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;

            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;

            } else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }



            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            //  print(temp);
            positionY -= distanceBetweenClouds;

        }


    }
    void Awake()
    {
        SetMinAndMax();
        CreateClouds();
        player = GameObject.Find("Player");

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);

        }

    }


    private void Start()
    {
        PositionThePlayer();
    }
    void PositionThePlayer()
    {

        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("deadly");
        GameObject[] whiteClouds = GameObject.FindGameObjectsWithTag("cloud");

        for (int i = 0; i < darkClouds.Length; i++)
        {
            if (darkClouds[i].transform.position.y == 0f)
            {
                Vector3 getDarkCloudAtStart = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3

                    (whiteClouds[i].transform.position.x,
                    whiteClouds[i].transform.position.y,
                    whiteClouds[i].transform.position.z);

                whiteClouds[i].transform.position = getDarkCloudAtStart;

            }
        }


        Vector3 firstWhiteCloud = whiteClouds[0].transform.position;
        //print("fwc"+firstWhiteCloud);

        for (int i = 1; i < whiteClouds.Length; i++)
        {
            if (firstWhiteCloud.y < whiteClouds[i].transform.position.y)
            {


                firstWhiteCloud = whiteClouds[i].transform.position;

            }
        }


        firstWhiteCloud.y += 0.7f;
        player.transform.position = firstWhiteCloud;

    }

    private void OnTriggerEnter2D(Collider2D target)
    {


        if (target.tag == "cloud"|| target.tag == "deadly")
        {
            if (target.transform.position.y == lastCloudPositionY)
            {
             //   print(lastCloudPositionY);

                ShuffleClouds(clouds);
                ShuffleClouds(collectables);

                Vector3 temp = target.transform.position;


                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {

                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;

                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }

                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);

                         if (clouds[i].tag != "deadly")
                            {
                            if(!collectables[random].activeInHierarchy)
                            {
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.5f;


                                if (collectables[random].tag =="life")
                                {

                                    if (PlayerScore.lifeCount < 100)
                                    {
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);

                                    }

                                    

                                }

                                else
                                {
                                    collectables[random].transform.position = temp2;
                                    collectables[random].SetActive(true);
                                }


                            }
                        }

                    }


                }





            }
        }
    }


}
