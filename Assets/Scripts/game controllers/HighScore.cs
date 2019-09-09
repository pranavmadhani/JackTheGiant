using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    

public class HighScore : MonoBehaviour

{
    [SerializeField]

    private Text coinText, scoreText;

    void setScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();

    }

    void setScoreBasedOnDifficulty()
    {
        if(prefs.GetEasyDifficulty()==1)
        {
            setScore(prefs.GetEasyDifficultyScore(), prefs.GetEasyDifficultyCoinScore());
        }

        if (prefs.GetMediumDifficulty() == 1)
        {
            setScore(prefs.GetMediumDifficultyScore(), prefs.GetMediumDifficultyCoinScore());
        }

        if (prefs.GetHardDifficulty() == 1)
        {
            setScore(prefs.GetHardDifficultyScore(), prefs.GetHardDifficultyCoinScore());
        }



    }

   




    void Start()
    {
        setScoreBasedOnDifficulty();
    }



    public void GoBackToMainMenu()
    {

        SceneManager.LoadSceneAsync("Menu");
    }
}
