using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float soundVolume = 5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        
        AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position, soundVolume);
        Destroy(gameObject);
    }
}
