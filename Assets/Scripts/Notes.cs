using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public int NoteSpeed = 5;
    bool start;

    void Update()
    {
        if(GameManager.instance.GetState() != GameState.PLAY)return;

        transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
               
    }
}
