using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    public GameObject pausePanel,gameOverPanel,readyButton,adsPanel;

    [SerializeField]
    private Button showAdsButtonCustom;

    public static bool IS_QUITING_THROUGH_PAUSE = false;



    public void GameOverShowPanel(int finalScore,int finalCoins)
    {
       //
        gameOverPanel.SetActive(true);

        gameOverScoreText.text = "x" + finalScore.ToString();
        gameOverCoinText.text = "x" + finalCoins.ToString();

        StartCoroutine(GameOverLoadMenu());

    }


    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(playerDiedRestart());
    }


    IEnumerator GameOverLoadMenu()
    {
        yield return new WaitForSeconds(3f);
      //  SceneManager.LoadSceneAsync("Menu");
        scenefader.instance.LoadLevel("Menu");
       


    }


    IEnumerator playerDiedRestart()
    {

        yield return new WaitForSeconds(1f);
       // SceneManager.LoadSceneAsync("main");
        scenefader.instance.LoadLevel("main");
    }



     void Awake()
    {
        MakeInstance();
    }


    public void pauseTheGame()
    {
        if(gameOverPanel.activeInHierarchy || readyButton.activeInHierarchy ||adsPanel.activeInHierarchy)
        {
            print("gameover panel is active I cannot switch to pause panel");
            pausePanel.SetActive(false);
           
        }

        else
        {
            print("pause panel loaded..");
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);
        }
        

    }


    public void resumeTheGame()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void quitTheGame()
    {
        IS_QUITING_THROUGH_PAUSE = true;
        print(IS_QUITING_THROUGH_PAUSE + "is this");
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);

        if (adsPanel.activeInHierarchy)
        {
            adsPanel.SetActive(false);
            
            GamePlayController.instance.GameOverShowPanel(PlayerScore.scoreCount, PlayerScore.coinCount);
            GameManager.instance.checkGameStatus(PlayerScore.scoreCount, PlayerScore.coinCount, PlayerScore.lifeCount);

        }

        else
        {
            GamePlayController.instance.GameOverShowPanel(PlayerScore.scoreCount, PlayerScore.coinCount);
            GameManager.instance.checkGameStatus(PlayerScore.scoreCount, PlayerScore.coinCount, PlayerScore.lifeCount);
            //scenefader.instance.LoadLevel("Menu");
        }
       

    }

    public void QuitTheGameThroughAdsPanel()
    {
        print("quitting through ads panel");
        Time.timeScale = 1.0f;
        showAddPanel(false);
        StartCoroutine(CustomCouritine.waitForSpecificSeconds(2f));  
        GamePlayController.instance.GameOverShowPanel(PlayerScore.scoreCount, PlayerScore.coinCount);
        
    }

    


    public void showAddPanel(bool status)
    {
       
        adsPanel.SetActive(status);
        Button btn = showAdsButtonCustom.GetComponent<Button>();
        btn.onClick.AddListener(CheckIfAddButtonIsClicked);
       


    }

    public void setScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void setCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void setLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;

    }

    public void showAds()

    {
        UnityAdsButton.instance.ShowAd();
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void onReadyButtonClick()
    {
        Time.timeScale = 1.0f;
        readyButton.SetActive(false);
    }

    
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //**********************************CUSTOM TRIAL CODE START****************************************//

    public void CheckIfAddButtonIsClicked()
    {
       

        string nameOfTheButtonClicked = showAdsButtonCustom.name;

        if (nameOfTheButtonClicked == "show ads")
        {

            print("clicked " + showAdsButtonCustom.name);
           

        }
        else
        {
            print("cannot show add");

        }
       
        

    }

   

    //**********************************CUSTOM CODE END****************************************//



}
