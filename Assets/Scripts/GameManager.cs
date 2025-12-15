using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲーム全体の状態を管理
public enum GameState
{
    INIT, // 初期化状態
    READY, 
    START, 
    PLAY, 
    RESULT
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float maxScore; //最大スコア（ノーツ総数×判定スコア）
    public float ratioScore; //現在のスコア割合（進捗率）

    public int songID; // 音楽番号
    public float noteSpeed; //ノーツの流れるスピード

    public float StartTime; //音楽の再生開始時間（MusicManagerで管理）

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
