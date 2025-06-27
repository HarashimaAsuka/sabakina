using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PageController : MonoBehaviour
{
   public string sceneName;
   public string thisSceneName;
   public float delayTime;

   void Start(){
      if(thisSceneName == "OpeningScene"){
         DelayGotoNextScene();
      }
   }
   
   public void GotoNextScene(){
      SceneManager.LoadScene(sceneName);
   }

   public void DelayGotoNextScene(){
      Invoke("GotoNextScene" , delayTime);
   }
}
