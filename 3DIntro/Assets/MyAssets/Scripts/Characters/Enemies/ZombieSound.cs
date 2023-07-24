using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    [SerializeField] float tiempoEntreSonidos = 5f;
    [SerializeField] AudioClip[] zombieSound;

    [SerializeField] AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        //InvokeRepeating("PlaySound", Random.Range(0, 5), tiempoEntreSonidos);
        Invoke("PlaySound", Random.Range(0, 0.5f));
    }

    void PlaySound ()
    {
        int randomAudioIndex = Random.Range(0, zombieSound.Length);
        //AudioSource.PlayClipAtPoint(zombieSound[randomAudioIndex], this.transform.position);

        _audioSource.clip = zombieSound[randomAudioIndex];
        _audioSource.Play();

        Invoke("PlaySound", _audioSource.clip.length + tiempoEntreSonidos);
        
    }


    void Update()
    {
        
    }
}
