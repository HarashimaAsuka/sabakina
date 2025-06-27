using System;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : NotesBaseManager
{    
    public void Initialize(string newSongName){
        noteNum = 0;
        songName = newSongName;
        Load(songName);
        Debug.Log(noteNum);
        GameManager.instance.maxScore = noteNum * 5;
    }
}