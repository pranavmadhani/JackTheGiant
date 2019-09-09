using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGspawner : MonoBehaviour
{
    private GameObject[] backgrounds;
    private float lastY;

    void getBGandSetLastY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("background");
        lastY = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if(lastY >backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag =="background")
        {
            if(target.transform.position.y== lastY)
            {
                Vector3 currentPosition = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if(!backgrounds[i].activeInHierarchy)
                    {
                        currentPosition.y -= height;
                        lastY = currentPosition.y;

                        backgrounds[i].transform.position = currentPosition;
                        backgrounds[i].SetActive(true);
                    }

                }

            }
        }
    }
    private void Start()
    {
        getBGandSetLastY();
    }

}
