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
            break;
            case "OpeningScene":
                GameManager.instance.SetState(GameState.READY);
                break;

            case "Airplane_Interior_Demo_URP": // GameScene
                //GameManager.instance.SetState(GameState.READY);
                Invoke("SetGamePlay", 2.0f);
                break;

            case "ResultScene":
                GameManager.instance.SetState(GameState.RESULT);
                break;
        }

        Debug.Log($"[MainContext] {scene} → {GameManager.instance.GetState()}");
    }

    public void SetGamePlay()
    {
        GameManager.instance.SetState(GameState.PLAY);
    }


}
