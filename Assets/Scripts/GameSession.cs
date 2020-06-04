using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 3;
    int score = 0;
     void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions>1){ Destroy(gameObject); }
        else{ DontDestroyOnLoad(gameObject); }
    }
    void Start()
    {
        
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
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
