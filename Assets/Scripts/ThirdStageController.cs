using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStageController : MonoBehaviour
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
        _musicManager.SetSongName("stage3");
        // _judge.endTime = 183.0f;//183.0f
        _notesManager.Initialize("stage3_enemy");        
        _passengerManager.Initialize("stage3_passenger");
        // _passengerJudge.SetDescendingPlaneSpeed(3.0f);
    }
}
