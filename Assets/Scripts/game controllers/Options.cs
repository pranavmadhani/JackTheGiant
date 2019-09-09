using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;


    void setInitialDifficulty(string difficulty)
    {

        switch(difficulty)
        {
            case "easy":

             
                mediumSign.SetActive(false);
                hardSign.SetActive(false);

                break;

            case "medium":

                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "hard":

                easySign.SetActive(false);
               mediumSign.SetActive(false);
                
                break;

        }
    }

    void setDiffuculty()
    {
        if (prefs.GetEasyDifficulty() == 1)
        {
            setInitialDifficulty("easy");

            easySign.SetActive(true);
            mediumSign.SetActive(false);
            hardSign.SetActive(false);
        }

        if (prefs.GetMediumDifficulty() == 1)
        {
            setInitialDifficulty("medium");

            mediumSign.SetActive(true) ;
            easySign.SetActive(false);
            hardSign.SetActive(false);
        }


        if (prefs.GetHardDifficulty() == 1)
        {
            setInitialDifficulty("hard");

            easySign.SetActive(false);
            mediumSign.SetActive(false);
            hardSign.SetActive(true);
        }

    }


    public void easyDifficulty()
    {
        prefs.SetEasyDifficulty(1);
        prefs.SetMediumDifficulty(0);
        prefs.SetHardDifficulty(0);

        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);



    }



    public void mediumDifficulty()
    {
        prefs.SetEasyDifficulty(0);
        prefs.SetMediumDifficulty(1);
        prefs.SetHardDifficulty(0);

        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }



    public void hardDifficulty()
    {
        prefs.SetEasyDifficulty(0);
        prefs.SetMediumDifficulty(0);
        prefs.SetHardDifficulty(1);

        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }

    void Start()
    {
        setDiffuculty();
    }

    public void GoBackToMainMenu()
    {

        SceneManager.LoadSceneAsync("Menu");
    }
}
