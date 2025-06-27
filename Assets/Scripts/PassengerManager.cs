using System;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : NotesBaseManager
{
    public void Initialize(string newSongName){
        noteNum = 0;
        songName = newSongName;
        Load(songName);
    }
}