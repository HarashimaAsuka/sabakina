using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float gameTime = 180;
    public Text gameoverText;
    public GameObject ResultCanvas;
    public Judge judge;

    private float restTime;
    private bool isPlaying = true;
    private Text timeText;
    
    void Start(){
        this.restTime = this.gameTime;//1103追記
        this.timeText = this.GetComponent<Text>();
        // gameoverText.gameObject.SetActive(false);
        ResultCanvas.SetActive(false);
    }

    void Update(){
        if(!isPlaying) return;

        if(GameManager.instance.GetState() != GameState.PLAY) return;

        if(restTime > 0){
            timeText.text = getRestTimeText();
        }

        if(!this.isPlaying){
            init();
        }

        this.restTime -= Time.deltaTime;

        if(this.restTime > 0){
            this.timeText.text = getRestTimeText();
        }
        else{
            this.timeText.text = "00:00";
            if(this.isPlaying){
                this.isPlaying = false;
                Time.timeScale = 0.0f;
                // gameoverText.gameObject.SetActive(true);
                // judge.resultGameclear.SetActive(false);1225
                // judge.resultGameoverText.SetActive(true);1225
                judge.resultTimeText.gameObject.SetActive(false);
                judge.TimezeroText.gameObject.SetActive(true);
                ResultCanvas.SetActive(true);
                if(judge != null){
                    StartCoroutine(judge.ShowResultAfterDelay());
                }
            }
        }
    }

    void init(){
        this.isPlaying = true;
        this.restTime = this.gameTime;
        Time.timeScale = 1.0f;

        this.timeText.text = getRestTimeText();
    }

    private string getRestTimeText(){
        int integer = Mathf.FloorToInt(this.restTime);
        return integer.ToString("00") + ":" + Mathf.FloorToInt((this.restTime - integer) * 100).ToString("00");
    }

    public void ReduceTime(float seconds){
        this.restTime -= seconds;
        if(this.restTime < 0)this.restTime = 0;
    }
    public float GetRemainingTime(){
        return restTime;
    }

    public void StopTime(){
        this.isPlaying = false;
        Time.timeScale = 0.0f;
    }
}
