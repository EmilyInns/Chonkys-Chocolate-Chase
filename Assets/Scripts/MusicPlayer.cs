using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        SetUpSingleton();
        audioSource = GetComponent<AudioSource>();
       // audioSource.volume = PlayerPrefsController.GetMasterVolume();
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

    public void setVolume(float volume)
    {
      //  audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

}
