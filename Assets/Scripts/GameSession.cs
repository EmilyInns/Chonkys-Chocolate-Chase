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
       SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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

    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
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


}
