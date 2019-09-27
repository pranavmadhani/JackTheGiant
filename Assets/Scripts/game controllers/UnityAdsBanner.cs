using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;
using UnityEngine.UI;
using ShowResult = UnityEngine.Monetization.ShowResult;

public class UnityAdsBanner : MonoBehaviour
{
    
    public string placementId = "InAddBanner";

    public static UnityAdsBanner instance;

    public void CheckStatus()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }



    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitWhile(() => Advertisement.IsReady(placementId));
        }
        //  Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(placementId);
    }

    // Start is called before the first frame update
    void Start()
    {

        CheckStatus();
        StartCoroutine(ShowBannerWhenReady());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
