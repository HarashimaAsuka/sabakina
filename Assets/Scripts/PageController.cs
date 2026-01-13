// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PageController : MonoBehaviour
// {
//    public string sceneName;
//    public string thisSceneName;
//    public float delayTime;
//    public GameObject gameOverResultCanvas;
//    public GameObject gameClearRsultCanvas;

//    void Start(){
//       if(thisSceneName == "OpeningScene"){
//          DelayGotoNextScene();
//       }
//    }

//  void Update()
// {
//     // 🔹 GameManager がいないシーン（Start / Opening）
//     if (GameManager.instance == null)
//     {
//         if (
//             Input.GetKeyDown(KeyCode.RightArrow) ||
//             Input.GetKeyDown("joystick button 0") ||
//             Input.GetKeyDown("joystick button 1")
//         )
//         {
//             GotoNextScene();
//         }
//         return;
//     }

//     // READY
//     if (
//         GameManager.instance.GetState() == GameState.READY &&
//         (
//             Input.GetKeyDown(KeyCode.RightArrow) ||
//             Input.GetKeyDown("joystick button 0") ||
//             Input.GetKeyDown("joystick button 1")
//         )
//     )
//     {
//         GotoNextScene();
//     }

//     // RESULT
//     if (
//         GameManager.instance.GetState() == GameState.RESULT &&
//         (
//             Input.GetKeyDown(KeyCode.RightArrow) ||
//             Input.GetKeyDown("joystick button 0") ||
//             Input.GetKeyDown("joystick button 1")
//         )
//     )
//     {
//         GotoNextScene();
//     }

//     // GameClear
//     if (
//         gameClearRsultCanvas != null &&
//         gameClearRsultCanvas.activeSelf &&
//         Input.GetKeyDown(KeyCode.RightArrow)
//     )
//     {
//         GotoNextScene();
//     }

//     // GameOver
//     if (
//         gameOverResultCanvas != null &&
//         gameOverResultCanvas.activeSelf &&
//         Input.GetKeyDown(KeyCode.RightArrow)
//     )
//     {
//         GotoNextScene();
//     }
// }


   
//    public void GotoNextScene(){
//       SceneManager.LoadScene(sceneName);
//    }

//    public void DelayGotoNextScene(){
//       Invoke("GotoNextScene" , delayTime);
//    }
// }




















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
   Debug.Log("State: " + GameManager.instance.GetState());

    // GameManager が存在しないシーンでは何もしない
    if (GameManager.instance == null) return;

    if(Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown("joystick button 0") ||
            Input.GetKeyDown("joystick button 1")){
        GotoNextScene();
    }

    if (    Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown("joystick button 0") ||
            Input.GetKeyDown("joystick button 1")
        
    )
    {
        GotoNextScene();
    }

    // GameClear
    if (
        gameClearRsultCanvas != null &&
        gameClearRsultCanvas.activeSelf &&
        (
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown("joystick button 1")
        )
    )
    {
        GotoNextScene();
    }

    // GameOver
    if (
        gameOverResultCanvas != null &&
        gameOverResultCanvas.activeSelf &&
        (
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown("joystick button 1")
        )
    )
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
