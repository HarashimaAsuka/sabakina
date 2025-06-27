using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
   public Text countdownText;
   public float countdownInterval = 0.686f;

   void Start(){
    StartCoroutine(CountdownCoroutine());
   }

   IEnumerator CountdownCoroutine(){
        for(int i = 3; i > 0; i--){
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(countdownInterval);
        }

        countdownText.text = "Start";
        yield return new WaitForSeconds(0.5f);
        countdownText.text = "";
    }
}