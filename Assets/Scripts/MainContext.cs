using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetState(GameState.INIT);
        StartCoroutine("GameSequence");
    }

    IEnumerator GameSequence(){
        yield return new WaitForSeconds(1.0f);
        GameManager.instance.SetState(GameState.PLAY);
        // yield return new WaitForSeconds(5.0f);
        // GameManager.instance.SetState(GameState.RESULT);
    }
}
