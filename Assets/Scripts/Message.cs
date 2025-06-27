using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    void Destroy(){
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy",3.0f);
    }
}
