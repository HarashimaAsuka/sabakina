using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabakinaAudio : MonoBehaviour
{
    public AudioClip Sabakina;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlaySabakinaVoice", 1.0f);
    }

    void PlaySabakinaVoice(){
        audioSource.PlayOneShot(Sabakina);
    }
}
