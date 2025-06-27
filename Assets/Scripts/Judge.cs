using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Cinemachine;
using UnityEngine.VFX;

public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] MessageObj;
    [SerializeField] NotesManager notesManager;
    [SerializeField] private GameObject lifeObj;

    [SerializeField] private Transform resultlifeGaugeParent;
    [SerializeField] private Transform lifeGaugeParent;

    [SerializeField] GameObject finish;
    // [SerializeField] public GameObject resultGameoverText;
    // [SerializeField] public GameObject resultGameclear;

    [SerializeField] TextMeshProUGUI comboText; 
    [SerializeField] TextMeshProUGUI scoreText;

    AudioSource audio;
    // [SerializeField] AudioClip hitSound;

    public Button Left;
    public Button Right;
    public Text clearText;
    public Text gameoverText;
    public Text perfectNumText;
    public Text greatNumText;
    public Text goodNumText;
    public Text badNumText;
    public Text missNumText;
    public Text resultTimeText;
    public Text TimezeroText;
    public Text resultScoreText;
    public GameObject ResultCanvas;
    public int enemycount;
    public int clearenemy;
    public GameObject GameCanvas;
    public GameObject DescendingPlane;
    public GameObject gameClearResultCanvas;
    public float speedrate = 1.0f;
    public float defaultspeed = 1.0f;
    public GameObject ImpulseSource;
    public VisualEffect rHitEffect;
    public VisualEffect lHitEffect;
    
    private int life;
    private int perfectNum;
    private int greatNum;
    private int goodNum;
    private int badNum;
    private int missNum;
    private float finalRemainingTime;

    public float endTime = 0;

    void Start(){
        Time.timeScale = 1.0f;
        SetLifeGauge(3);
        enemycount = 0;
        clearText.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(false);
        GameManager.instance.ratioScore = 0;
        GameManager.instance.combo = 0;
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        // Debug.Log(GameManager.instance.GetState());
        if(GameManager.instance.GetState() != GameState.PLAY) return;
            if(Time.time > endTime + GameManager.instance.StartTime){
                finish.SetActive(true);
                GameManager.instance.SetState(GameState.RESULT);
                StartCoroutine(ShowResultAfterDelay());
                return;
            }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            OnClickLeftButton();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            OnClickRightButton();
        }

            if(notesManager.LaneNum.Count > 0 && notesManager.NotesTime.Count > 0){       
                if(Time.time > notesManager.NotesTime[0] + 0.2f + GameManager.instance.StartTime){
                    DescendingPlane.GetComponent<DescendingPlane>().AddSpeed(defaultspeed * speedrate);
                    message(3, notesManager.LaneNum[0]);
                    GameManager.instance.combo = 0;
                    deleteData();
                    SetLifeGauge2(1);
                    missNum++;
                    missNumText.text = missNum.ToString();
                    var impulseSource = ImpulseSource.GetComponent<CinemachineImpulseSource>();//0408
                    impulseSource.GenerateImpulse();//0408
                    Debug.Log("Miss");
                }
            }
    }

    public void OnClickLeftButton(){
        if(GameManager.instance.GetState() != GameState.PLAY) return;
        if(Input.GetKeyDown(KeyCode.LeftArrow) != null && notesManager.LaneNum.Count > 0 && notesManager.LaneNum[0] == 0){
            // if(notesManager.LaneNum[0] == 1){
            Judgement(GetABS(Time.time-(notesManager.NotesTime[0] + GameManager.instance.StartTime)));
            // }
        }
    }   

    public void OnClickRightButton(){
        if(GameManager.instance.GetState() != GameState.PLAY) return;
        if(Input.GetKeyDown(KeyCode.RightArrow) != null  && notesManager.LaneNum.Count > 0 && notesManager.LaneNum[0] == 1){
            // if(notesManager.LaneNum[0] == 2){
            Judgement(GetABS(Time.time-(notesManager.NotesTime[0] + GameManager.instance.StartTime)));
            // }
        }
    }    

    void Judgement(float timeLag){
        // audio.PlayOneShot(hitSound);1220
        int judge = 3;

        Debug.Log("Time Lag: " + timeLag);

        if(timeLag <= 0.10){
            Debug.Log("Perfect");
            judge = 0;
            enemycount++;
            perfectNum++;
            perfectNumText.text = perfectNum.ToString();
            GameManager.instance.ratioScore += 5;
            GameManager.instance.combo++;
            if(notesManager.LaneNum[0] == 0){
                lHitEffect.Play();
            }
            else if(notesManager.LaneNum[0] == 1){
                rHitEffect.Play();
            }
        }

        else if(timeLag <= 0.15f){
            Debug.Log("Great");
            judge = 1;
            enemycount++;
            greatNum++;
            greatNumText.text = greatNum.ToString();
            GameManager.instance.ratioScore += 3;
            GameManager.instance.combo++;
            if(notesManager.LaneNum[0] == 0){
                lHitEffect.Play();
            }
            else if(notesManager.LaneNum[0] == 1){
                rHitEffect.Play();
            }
        }

        else if(timeLag <= 0.20f){
            Debug.Log("Bad");
            judge = 2;
            enemycount++;
            badNum++;
            badNumText.text = badNum.ToString();
            GameManager.instance.ratioScore += 1;
            GameManager.instance.combo = 0;
            if(notesManager.LaneNum[0] == 0){
                lHitEffect.Play();
            }
            else if(notesManager.LaneNum[0] == 1){
                rHitEffect.Play();
            }
        }

        if(notesManager.LaneNum.Count > 0){
            message(judge, notesManager.LaneNum[0]);
            // deleteData();
        }
        
        if(judge <= 2){
            deleteData();
        }
    }

    float GetABS(float num){
        // if(num >= 0){
        //     return num;
        // }
        // else{
        //     return -num;
        // }
        return Mathf.Abs(num);
    }

    void deleteData(){
        if(notesManager.NotesTime.Count > 0) notesManager.NotesTime.RemoveAt(0);
        if(notesManager.LaneNum.Count > 0) notesManager.LaneNum.RemoveAt(0);
        if(notesManager.NoteType.Count > 0) notesManager.NoteType.RemoveAt(0);

        if(notesManager.NotesObj.Count > 0){
            Destroy(notesManager.NotesObj[0]);
            notesManager.NotesObj.RemoveAt(0);
        }

        GameManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GameManager.instance.ratioScore / GameManager.instance.maxScore * 1000000) / 1000000);

        comboText.text = GameManager.instance.combo.ToString();
        scoreText.text = GameManager.instance.score.ToString();
    }

    void message(int judge, int laneNum){
        GameObject Obj = Instantiate(MessageObj[judge], Vector3.zero,Quaternion.Euler(0,0,0));
        Obj.transform.parent = GameCanvas.transform;
        Obj.GetComponent <RectTransform>().anchoredPosition = new Vector3(0,-106,0);
    }

    public void SetLifeGauge(int newLife){
        life = newLife;

        for(int i = 0; i < lifeGaugeParent.childCount; i++){
            Destroy(lifeGaugeParent.GetChild(i).gameObject);
        }
          for(int i = 0; i < lifeGaugeParent.childCount; i++){
            Destroy(resultlifeGaugeParent.GetChild(i).gameObject);
        }    

        for(int i = 0; i < life; i++){
            Instantiate<GameObject>(lifeObj, lifeGaugeParent);
        }
        for(int i = 0; i < life; i++){
            Instantiate<GameObject>(lifeObj, resultlifeGaugeParent);
        }
    }

    public void SetLifeGauge2(int damage){
        life -= damage;
        int currentLife = lifeGaugeParent.childCount;
        int currentResultLife = resultlifeGaugeParent.childCount;
        int amountToRemove = Mathf.Min(damage,currentLife);
        int amountToRemoveResult = Mathf.Min(damage,currentResultLife);

        Debug.Log($"Attempting to remove {amountToRemove} life(s). Current life:{currentLife}");
        
        for(int i = 0; i < amountToRemove; i++){
            // Destroy(transform.GetChild(i).gameObject);
            Destroy(lifeGaugeParent.GetChild(lifeGaugeParent.childCount - 1 - i).gameObject);
            Debug.Log("Removed a life.");
        }
        for(int i = 0; i < amountToRemoveResult; i++){
            // Destroy(transform.GetChild(i).gameObject);
            Destroy(resultlifeGaugeParent.GetChild(resultlifeGaugeParent.childCount - 1 - i).gameObject);
            Debug.Log("Removed a life.");
        }
    }

    public void gameClear(){
        clearText.gameObject.SetActive(true);
        Debug.Log("GameClear");
        Time.timeScale = 0.0f;
    }
    
    public IEnumerator ShowResultAfterDelay(){
        // FindObjectOfType<TimeManager>().StopTime();1225
        // finalRemainingTime = FindObjectOfType<TimeManager>().GetRemainingTime();
        
        // float GetRemainingTime = FindObjectOfType<TimeManager>().GetRemainingTime();
        // resultTimeText.text = FormatTime(finalRemainingTime);

        perfectNumText.text = perfectNum.ToString();
        greatNumText.text = greatNum.ToString();
        badNumText.text = badNum.ToString();
        missNumText.text = missNum.ToString();
        // resultScoreText.text = ((int)Math.Round(1000000 * Math.Floor(GameManager.instance.ratioScore / GameManager.instance.maxScore * 1000000) / 1000000)).ToString();

        yield return new WaitForSecondsRealtime(3f);      
        gameClearResultCanvas.SetActive(true);
        ResultCanvas.SetActive(true);
    }

    private string FormatTime(float time){
        int seconds = Mathf.FloorToInt(time);
        int milliseconds = Mathf.FloorToInt((time - seconds) * 100);
        return seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}