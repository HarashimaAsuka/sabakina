using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScondStageController : MonoBehaviour
{
    public DescendingPlane _descendingPlane;
    public MusicManager _musicManager;
    public Judge _judge;
    public NotesManager _notesManager;
    public PassengerManager _passengerManager;
    public PassengerJudge _passengerJudge;
    
    void Start()
    {
        // _descendingPlane.SetSpeed(1.0f);
        _musicManager.SetSongName("stage2");
        // _judge.endTime = 155.0f;
        _notesManager.Initialize("stage2_enemy");        
        _passengerManager.Initialize("stage2_passenger");
        // _passengerJudge.SetDescendingPlaneSpeed(3.0f);
    }
}
