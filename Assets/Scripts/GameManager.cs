using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    INIT,
    READY,
    START,
    PLAY,
    RESULT
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float maxScore;
    public float ratioScore;

    public int songID;
    public float noteSpeed;

    public float StartTime;

    public int combo;
    public int score;

    public int perfect;
    public int great;
    public int bad;
    public int miss;

    GameState state = GameState.INIT;

    public void SetState(GameState _state){
        state =  _state;
    }

    public GameState GetState(){
        return state;
    }
    
    public void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }
}
