// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MainContext : MonoBehaviour
// {
//     void Start()
//     {
//         Debug.Log("MainContext Start");

//         if (GameManager.instance == null)
//         {
//             Debug.LogError("GameManager is null");
//             return;
//         }

//         // 現在のシーン名を取得
//         string currentScene = SceneManager.GetActiveScene().name;
//         Debug.Log("Scene: " + currentScene);

//         switch (currentScene)
//         {
//             case "StartScene":
//                 // スタート画面：入力待ち
//                 GameManager.instance.SetState(GameState.READY);
//                 break;

//             case "OpeningScene":
//                 // オープニング：演出＋入力待ち
//                 GameManager.instance.SetState(GameState.READY);
//                 break;

//             case "Airplane_Interior_Demo_URP":
//                 // ゲーム開始
//                 GameManager.instance.SetState(GameState.PLAY);
//                 break;

//             default:
//                 Debug.LogWarning("MainContext: 未対応のシーンです → " + currentScene);
//                 break;
//         }

//         Debug.Log("MainContext State: " + GameManager.instance.GetState());
//     }
// }




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MainContext : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         GameManager.instance.SetState(GameState.INIT);
//         StartCoroutine("GameSequence");
//     }

//     IEnumerator GameSequence(){
//         yield return new WaitForSeconds(1.0f);
//         GameManager.instance.SetState(GameState.PLAY);
//         // yield return new WaitForSeconds(5.0f);
//         // GameManager.instance.SetState(GameState.RESULT);
//     }
// }







































using UnityEngine;
using UnityEngine.SceneManagement;

public class MainContext : MonoBehaviour
{
    void Start()
    {
        if (GameManager.instance == null) return;

        string scene = SceneManager.GetActiveScene().name;

        switch (scene)
        {
            case "StartScene":
            case "OpeningScene":
                GameManager.instance.SetState(GameState.READY);
                break;

            case "Airplane_Interior_Demo_URP": // GameScene
                GameManager.instance.SetState(GameState.PLAY);
                break;

            case "ResultScene":
                GameManager.instance.SetState(GameState.RESULT);
                break;
        }

        Debug.Log($"[MainContext] {scene} → {GameManager.instance.GetState()}");
    }
}
