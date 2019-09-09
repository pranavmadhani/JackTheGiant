 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenefader : MonoBehaviour
{
    public static scenefader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnime;


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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));   
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnime.Play("fade in");

        yield return CustomCouritine.waitForRealSeconds(0.7f);

        SceneManager.LoadSceneAsync(level);
        fadeAnime.Play("fade out");


        yield return CustomCouritine.waitForRealSeconds(0.7f);
        fadePanel.SetActive(false);
    }


    void Awake()
    {
        MakeSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
