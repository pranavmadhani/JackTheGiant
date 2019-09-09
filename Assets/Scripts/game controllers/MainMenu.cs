using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    void Start()
    {
        checkToPlayTheMusic();
    }


    void checkToPlayTheMusic()
    {
        if (prefs.GetMusicOn() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }

        else
        {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }


    public void MusicButton()
    {
        if (prefs.GetMusicOn() == 0)
        {
            print("music btn clicked");
            prefs.SetMusicOn(1) ;
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }

        else if(prefs.GetMusicOn() == 1)
        {
            prefs.SetMusicOn(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }


    public void startGame()
    {

        GameManager.instance.gameStartedFromMainMenu = true ;
        GameManager.instance.gameRestartedAfterPlayerDied = false;  
        // SceneManager.LoadSceneAsync("main");

        scenefader.instance.LoadLevel("main");
    }

    public void highScore()
    {
        SceneManager.LoadSceneAsync("highscore");
    }
    public void options()
    {
        SceneManager.LoadSceneAsync("options");
    }
    public void menu()
    {
        SceneManager.LoadSceneAsync("menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }



    


    // Update is called once per frame
    void Update()
    {
        
    }
}
