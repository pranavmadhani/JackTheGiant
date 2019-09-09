using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;
using System.Collections;

[RequireComponent(typeof(Button))]
public class UnityAdsButton : MonoBehaviour
    {

    public static UnityAdsButton instance;

    string gameId = "3283000";
    public string placementIdOfRewardVideo = "rewardedVideo";
    private Button adButton;
    public static bool REWARD_STATUS = false;
   


   

    public void Start()
    {

       




        adButton = GetComponent<Button>();
        if (adButton)
        {
            adButton.onClick.AddListener(ShowAd);
        }

        if (Monetization.isSupported)
        {
            Monetization.Initialize(gameId, true);
        }
    }

    public void Update()
    {
        if (adButton)
        {
            adButton.interactable = Monetization.IsReady(placementIdOfRewardVideo);
        }
    }

   public void ShowAd()
    {
       

        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementIdOfRewardVideo) as ShowAdPlacementContent;
        ad.Show(options);
    }

    public void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
           
            REWARD_STATUS = true;
            print("Life Count ++");

            GamePlayController.instance.setLifeScore(GameManager.GLOBAL_LIFE_COUNT + 1);
            PlayerScore.lifeCount = GameManager.GLOBAL_LIFE_COUNT + 1;

            GameManager.instance.checkGameStatus(PlayerScore.scoreCount, PlayerScore.coinCount, PlayerScore.lifeCount);

            GamePlayController.instance.showAddPanel(false);

        }
        else if (result == ShowResult.Skipped)

        {
            GamePlayController.instance.quitTheGame();

            Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            GamePlayController.instance.quitTheGame();
            Debug.LogError("Video failed to show");
        }


        
    }
}