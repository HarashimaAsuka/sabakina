using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageController : MonoBehaviour
{
    public DescendingPlane _descendingPlane;
    public MusicManager _musicManager;
    public Judge _judge;
    public NotesManager _notesManager;
    public PassengerManager _passengerManager;
    public PassengerJudge _passengerJudge;
    
    void Start()
    {
        // _descendingPlane.SetSpeed(1);
        _musicManager.SetSongName("宇宙の戦士_Audio Trimmer");
        // _judge.endTime = 73.0f;
        _notesManager.Initialize("宇宙の戦士_enemy");        
        _passengerManager.Initialize("宇宙の戦士_passenger");
        // _passengerJudge.SetDescendingPlaneSpeed(3.0f);
    }

    // void Update(){
    //     if(GameManager.instance.GetState() != GameState.PLAY) return;
    //     if(_notesManager.LaneNum.Count > 0 && _notesManager.NotesTime.Count > 0){     
    //         if(Time.time > _notesManager.NotesTime[0] + 0.2f + GameManager.instance.StartTime){
    //             _descendingPlane.AddSpeed(1);
    //         }
    //     }
    // }
}

