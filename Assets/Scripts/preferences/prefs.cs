using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class prefs 
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyScore = "EasyDifficultyScore";
    public static string MediumDifficultyScore = "MediumDifficultyScore";
    public static string HardDifficultyScore = "HardDifficultyScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";


    // LEVEL DIFFICULTY STARTS

    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.EasyDifficulty, difficulty);
    }


    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(prefs.EasyDifficulty);
    }



    public static void SetMediumDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.MediumDifficulty, difficulty);
    }


    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(prefs.MediumDifficulty);
    }


    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.HardDifficulty, difficulty);
    }


    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(prefs.HardDifficulty);
    }



    // LEVEL DIFFICULTY ENDS


    // SCORE DIFFICULTY STARTS

    public static void SetEasyDifficultyScore(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.EasyDifficultyScore, difficulty);
    }


    public static int GetEasyDifficultyScore()
    {
        return PlayerPrefs.GetInt(prefs.EasyDifficultyScore);
    }



    public static void SetMediumDifficultyScore(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.MediumDifficultyScore, difficulty);
    }


    public static int GetMediumDifficultyScore()
    {
        return PlayerPrefs.GetInt(prefs.MediumDifficultyScore);
    }


    public static void SetHardDifficultyScore(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.HardDifficultyScore, difficulty);
    }


    public static int GetHardDifficultyScore()
    {
        return PlayerPrefs.GetInt(prefs.HardDifficultyScore);
    }


    // SCORE DIFFICULTY ENDS


    // COIN SCORE DIFFICULTY STARTS

    public static void SetEasyDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.EasyDifficultyCoinScore, difficulty);
    }


    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(prefs.EasyDifficultyCoinScore);
    }



    public static void SetMediumDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.MediumDifficultyCoinScore, difficulty);
    }


    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(prefs.MediumDifficultyCoinScore);
    }


    public static void SetHardDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(prefs.HardDifficultyCoinScore, difficulty);
    }


    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(prefs.HardDifficultyCoinScore);
    }

    // COIN SCORE DIFFICULTY ENDS


    // MUSIC STARTS

    public static void SetMusicOn(int music)
    {
        PlayerPrefs.SetInt(prefs.IsMusicOn, music);
    }


    public static int GetMusicOn()
    {
        return PlayerPrefs.GetInt(prefs.IsMusicOn);
    }
  
    // MUSIC ENDS



}
