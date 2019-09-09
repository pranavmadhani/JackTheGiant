using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent < SpriteRenderer>();
        Vector3 vector3 = transform.localScale;

        float width = spriteRenderer.sprite.bounds.size.x;
        float worldHeight = Camera.main.orthographicSize*2.0f;
        float worldWidth = (worldHeight /( Screen.height*0.9f)) * Screen.width;

        vector3.x = worldWidth / width;
        transform.localScale = vector3;
    }

  
}
