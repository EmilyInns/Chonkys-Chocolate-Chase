using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    AudioSource audioSource;
    protected GameSession gameSession;
    protected Player player;
    [SerializeField] float soundVolume = 5f;
    [SerializeField] protected int scoreValue = 100;
    // Start is called before the first frame update
    protected void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D other){
        
        PickedUp();
        
    }

    protected void PickedUp()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position, soundVolume);
        PickupEffect();
        Destroy(gameObject);
    }

    protected virtual void PickupEffect()
    {
        gameSession.addScore(scoreValue);
    }
}
