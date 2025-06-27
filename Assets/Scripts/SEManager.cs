using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private AudioSource hornsound;

    void Start(){
        hornsound = GetComponent<AudioSource>();
    }

    public void OnClickSE(){
        hornsound.PlayOneShot(hornsound.clip);
    }
}
