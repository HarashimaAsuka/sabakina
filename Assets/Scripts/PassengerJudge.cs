using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PassengerJudge : MonoBehaviour
{
    [SerializeField]PassengerManager passengerManager;
    [SerializeField]TimeManager timeManager;

    public Button Left;
    public Button Right;
    public GameObject DescendingPlane;
    public GameObject ImpulseSource;
    

    private bool isJudged = false;

    void Start(){
        
    }

    void Update(){
        if(GameManager.instance.GetState() != GameState.PLAY) return;
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            OnClickLeftButton();
            Debug.Log("ひだり");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            OnClickRightButton();
            Debug.Log("みぎ");
        }
        if(passengerManager.LaneNum.Count > 0 && passengerManager.NotesTime.Count > 0){
            if(Time.time > passengerManager.NotesTime[0] + 0.2f + GameManager.instance.StartTime){
                SetDescendingPlaneSpeed(0.9f);
                // DescendingPlane.GetComponent<DescendingPlane>().multiplicationSpeed(0.9f);
                // message(3,passengerManager.LaneNum[0]);
                Debug.Log("Safe");
                isJudged=true;//追記
                deleteData();
            }
        }
        
    }

    public void OnClickLeftButton(){
        if(passengerManager.LaneNum.Count > 0 && passengerManager.LaneNum[0] == 0){
            Judgement(GetABS(Time.time - (passengerManager.NotesTime[0] + GameManager.instance.StartTime)));
            // var impulseSource = ImpulseSource.GetComponent<CinemachineImpulseSource>();//0408
            // impulseSource.GenerateImpulse();
        }
    }

    public void OnClickRightButton(){
        if(passengerManager.LaneNum.Count > 0 && passengerManager.LaneNum[0] == 1){
            Judgement(GetABS(Time.time - (passengerManager.NotesTime[0] + GameManager.instance.StartTime)));
            // var impulseSource = ImpulseSource.GetComponent<CinemachineImpulseSource>();//0408
            // impulseSource.GenerateImpulse();
        }
    }

    void Judgement(float timeLag){
        // int judge = 3;

        Debug.Log("Time Lag:" + timeLag);

        if(timeLag <= 0.20f){
            Debug.Log("out");
            isJudged = true;
            timeManager.ReduceTime(5.0f);

            deleteData();
            Debug.Log("Data deleted after out judgment");

            var impulseSource = ImpulseSource.GetComponent<CinemachineImpulseSource>();//0408
            impulseSource.GenerateImpulse();

            // DescendingPlane.GetComponent<DescendingPlane>().AddSpeed(10);

            // if(passengerManager.LaneNum.Count > 1){
            //     deleteData();
            // }
            // else{
            //     deleteData();
            //     Debug.Log("Last note - data deleted ajter judgment");
            // }
            
            // // judge = 2;
        }
        else if(timeLag > 0.20f && isJudged == false){
            SetDescendingPlaneSpeed(0.9f);
            // DescendingPlane.GetComponent<DescendingPlane>().multiplicationSpeed(0.9f);
            Debug.Log("safe");
            isJudged = true;
        }
    }

    float GetABS(float num){
        return Mathf.Abs(num);
    }

    void deleteData(){
        if(passengerManager.NotesTime.Count > 0) passengerManager.NotesTime.RemoveAt(0);
        if(passengerManager.LaneNum.Count > 0) passengerManager.LaneNum.RemoveAt(0);
        if(passengerManager.NoteType.Count > 0) passengerManager.NoteType.RemoveAt(0);

        if(passengerManager.NotesObj.Count > 0){
            Destroy(passengerManager.NotesObj[0]);
            passengerManager.NotesObj.RemoveAt(0);
        }

        isJudged = false;
    }

    // void message(int judge, int laneNum){
    //     Instantiate(MessageObj[judge], new Vector3(laneNum - 1.5f,0.76f,0.15f),Quaternion.Euler(45,0,0));
    // }

    public void SetDescendingPlaneSpeed(float speed){
        DescendingPlane.GetComponent<DescendingPlane>().multiplicationSpeed(speed);
    }
}