using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageController : MonoBehaviour
{
   public string sceneName;
   public string thisSceneName;
   public float delayTime;
   public GameObject gameOverResultCanvas;
   public GameObject gameClearRsultCanvas;

   void Start(){
      if(thisSceneName == "OpeningScene"){
         DelayGotoNextScene();
      }
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("joystick button 0")|| Input.GetKeyDown("joystick button 1"))
        {
            GotoNextScene();
        }

      if (gameClearRsultCanvas.activeSelf && Input.GetKeyDown(KeyCode.RightArrow))
      {
         GotoNextScene();
      }

      if(gameOverResultCanvas.activeSelf && Input.GetKeyDown(KeyCode.RightArrow))
      {
         GotoNextScene();
      }
   }
   
   public void GotoNextScene(){
      SceneManager.LoadScene(sceneName);
   }

   public void DelayGotoNextScene(){
      Invoke("GotoNextScene" , delayTime);
   }
}
