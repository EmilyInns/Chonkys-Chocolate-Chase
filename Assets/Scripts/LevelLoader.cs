﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        FindObjectOfType<GameSession>().ResetGameSession();
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

        public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

}
