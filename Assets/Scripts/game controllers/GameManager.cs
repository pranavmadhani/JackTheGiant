using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;
using UnityEngine.UI;
using ShowResult = UnityEngine.Monetization.ShowResult;

public class GameManager : MonoBehaviour
{

    string gameId = "3283000";
    public string placementId = "InAddBanner";
    public string placementIdOfRewardAdd = "rewardedVideo";
    bool testMode = true;
    public  static int GLOBAL_LIFE_COUNT=0;
    public Button adsButton;

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

  


      

    void Start() {

        initializeVariables();
      //  StartCoroutine(ShowBannerWhenReady());
       

    }

    //IEnumerator ShowBannerWhenReady()
    //{
    //    while (!Advertisement.IsReady(placementId))
    //    {
    //        yield return new WaitWhile(() => Advertisement.IsReady(placementId));
    //    }
    //  //  Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    //    Advertisement.Banner.Show(placementId);
    //}

    void initializeVariables()
    {
        if(!PlayerPrefs.HasKey("any key"))
        {

            prefs.SetEasyDifficulty(0);
            prefs.SetEasyDifficultyCoinScore(0);
            prefs.SetEasyDifficultyScore(0);

            prefs.SetMediumDifficulty(1);
            prefs.SetMediumDifficultyCoinScore(0);
            prefs.SetMediumDifficultyScore(0);

            prefs.SetHardDifficulty(0);
            prefs.SetHardDifficultyCoinScore(0);
            prefs.SetHardDifficultyScore(0);

            prefs.SetMusicOn(0);
            PlayerPrefs.SetInt("any key", 999);


        }
    }

    void Awake()
    {
        MakeSingleton();
        Advertisement.Initialize(gameId, testMode);
       

    }


    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }



    void OnLevelWasLoaded()
    {
        string scene = SceneManager.GetActiveScene().name.ToString();




        if (scene == "main")
        {
            print("inside if");

            if (gameRestartedAfterPlayerDied)
            {
                print("game started after player died");
                GamePlayController.instance.setScore(score);
                GamePlayController.instance.setCoinScore(coinScore);
                GamePlayController.instance.setLifeScore(lifeScore);


                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }

            else if (gameStartedFromMainMenu)
            {
                print("game started from main menu");
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GamePlayController.instance.setScore(0);
                GamePlayController.instance.setCoinScore(0);
                GamePlayController.instance.setLifeScore(2);



            }


        }


        else
        {
            print("other scene except main loaded ");
        }

    }


    public void checkGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0 )
        {
            GamePlayController.instance.showAddPanel(true);
           

            if (prefs.GetEasyDifficulty() == 1)
            {
                int HS = prefs.GetEasyDifficultyScore();
                int CS = prefs.GetEasyDifficultyCoinScore();

                if (HS < score)
                {
                    prefs.SetEasyDifficultyScore(score);
                }

                if (CS < coinScore)
                {
                    prefs.SetEasyDifficultyCoinScore(coinScore);
                }

            }


            if (prefs.GetMediumDifficulty() == 1)
            {
                int HS = prefs.GetMediumDifficultyScore();
                int CS = prefs.GetMediumDifficultyCoinScore();

                if (HS < score)
                {
                    prefs.SetMediumDifficultyScore(score);
                }

                if (CS < coinScore)
                {
                    prefs.SetMediumDifficultyCoinScore(coinScore);
                }

            }

            if (prefs.GetHardDifficulty() == 1)
            {
                int HS = prefs.GetHardDifficultyScore();
                int CS = prefs.GetHardDifficultyCoinScore();

                if (HS < score)
                {
                    prefs.SetHardDifficultyScore(score);
                }

                if (CS < coinScore)
                {
                    prefs.SetHardDifficultyCoinScore(coinScore);
                }

            }



            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            // GamePlayController.instance.GameOverShowPanel(score, coinScore);

        }

        else if ( GamePlayController.IS_QUITING_THROUGH_PAUSE)
        {
            print("quitting through pause panel");
            GamePlayController.instance.showAddPanel(false);
            

            if (prefs.GetEasyDifficulty() == 1)
            {
                int HS = prefs.GetEasyDifficultyScore();
                int CS = prefs.GetEasyDifficultyCoinScore();

                if (HS < score)
                {
                    prefs.SetEasyDifficultyScore(score);
                }

                if (CS < coinScore)
                {
                    prefs.SetEasyDifficultyCoinScore(coinScore);
                }

            }


            if (prefs.GetMediumDifficulty() == 1)
            {
                int HS = prefs.GetMediumDifficultyScore();
                int CS = prefs.GetMediumDifficultyCoinScore();

                if (HS < score)
                {
                    prefs.SetMediumDifficultyScore(score);
                }

                if (CS < coinScore)
                {
                    prefs.SetMediumDifficultyCoinScore(coinScore);
                }

            }

            if (prefs.GetHardDifficulty() == 1)
            {
                int HS = prefs.GetHardDifficultyScore();
                int CS = prefs.GetHardDifficultyCoinScore();

                if (HS < score)
                {
                    prefs.SetHardDifficultyScore(score);
                }

                if (CS < coinScore)
                {
                    prefs.SetHardDifficultyCoinScore(coinScore);
                }

            }


        }



        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;
            GamePlayController.instance.PlayerDiedRestartTheGame();
        }
    }








}
