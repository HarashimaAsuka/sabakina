using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    public DescendingPlane descendingPlane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(descendingPlane.AirplanePosY > 80){
            //揺れない
        }
        else if(descendingPlane.AirplanePosY > 50){
            Shake(2.0f);
        }
        else if(descendingPlane.AirplanePosY > 30){
            Shake(5.0f);
        }
        else if(descendingPlane.AirplanePosY > 10){
            Shake(10.0f);
        }
        else{
            Shake(15.0f);
        }
    }

    void Shake(float slant){
        float angle = slant * Mathf.Sin(Time.time * 2f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);        
    }
}
