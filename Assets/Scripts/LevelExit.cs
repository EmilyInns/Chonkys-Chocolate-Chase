using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 3f;

    AudioSource audioSource;

    void Start(){

        audioSource = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D other){
        if(!audioSource.isPlaying){ audioSource.Play(0); }
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel(){
        yield return new WaitForSeconds(levelLoadDelay);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
