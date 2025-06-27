using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioClip Music;
    public string songName;
    private bool played;

    void Start(){
        // songName = "宇宙の戦士_Audio Trimmer";
        audioSource = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
    }

    void Update(){
        if(GameManager.instance.GetState() != GameState.PLAY) return;
        
        if(!played)
        {

            if(Music == null){
                Debug.Log("AudioClipが設定されいません");
                return;
            }
            GameManager.instance.StartTime = Time.time;
            played = true;
            audioSource.PlayOneShot(Music);
        }
    }

    public void SetSongName(string newSongName){
        songName = newSongName;
        Music = (AudioClip)Resources.Load("Musics/" + songName);
    }
}
