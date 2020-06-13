using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 3f;
    [SerializeField] GameObject VictoryVFX;

    AudioSource audioSource;

    void Start(){

        audioSource = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D other){
        Player player = other.GetComponent<Player>();
        if(player&&player.GetIsAlive()){
            player.setFrozen(true);

        var VFXRotation = new Vector3(-90,0,1);
        Quaternion myRotation = Quaternion.identity;
        myRotation.eulerAngles = VFXRotation;
        
            GameObject VictoryVFXobject = Instantiate(VictoryVFX, transform.position, myRotation);
            if(!audioSource.isPlaying){ audioSource.Play(); }
            StartCoroutine(LoadNextLevel());

        } 
    }

    IEnumerator LoadNextLevel(){
        yield return new WaitForSeconds(levelLoadDelay);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevel(){
         StartCoroutine(LoadNextLevel());
    }
}
