using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescendingPlane : MonoBehaviour
{
    public float AirplanePosY = 100;
    public float speed = 1;
    public GameObject gameOverResultCanvas;
    public Text GameOverText;
    public float Maxpos = 497;
    public float Minpos = 157;
    public GameObject Plane;
    public GameObject resultCanvas;

    void Update(){
        if(GameManager.instance.GetState() != GameState.PLAY)return;
        AirplanePosY -= speed * Time.deltaTime;
        // Debug.Log(AirplanePosY);

        MovePlane();

        if(AirplanePosY <= 0){
            GameOverText.gameObject.SetActive(true);
            StartCoroutine(SetActiveResultCanvas(3));
            Time.timeScale = 0;
        }
    }

    public float GetPlaneRatio(){
        return AirplanePosY;
    }

    public float GetCurrentLocation(){
        float distance = Maxpos - Minpos;
        float num = distance * AirplanePosY / 100;
        return num;
    }

    //飛行機の降下処理
    void MovePlane(){
        float num = GetCurrentLocation();
        // Debug.Log(num);
        Plane.GetComponent <RectTransform>().anchoredPosition = new Vector3(-762.0f,Minpos + num,0);
    }

    public void SetSpeed(float value){
        speed = value;
    }

    public void AddSpeed(float value){
        speed += value;
    }

    public float GetSpeed(){
        return speed;
    }

    public void multiplicationSpeed(float value){
        speed = speed * value;
    }

    //ゲームオーバー前に少し待機
    IEnumerator SetActiveResultCanvas(float delay){
        float pausedTime = 0f;

        while(pausedTime < delay){
            pausedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        gameOverResultCanvas.SetActive(true);
        resultCanvas.SetActive(true);
    }
}
