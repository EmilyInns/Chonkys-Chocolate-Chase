using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 3;
    int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

     void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions>1){ Destroy(gameObject); }
        else{ DontDestroyOnLoad(gameObject); }
    }
    void Start()
    {
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath(){
        
        if(lives>1){
            TakeLife();
        }
        else{
            
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        lives--;
        UpdateText();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void AddLife(){
        lives++;
        UpdateText();
    }

    private void ResetGameSession()
    {
        LoadMainMenu();
        Destroy(gameObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

        public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void addScore(int amount){
        Debug.Log("Adding " + amount);
        score += amount;
        UpdateText();
    }

    private void UpdateText(){
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
    }

        public void QuitGame()
    {
        Application.Quit();
    }
}
