using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearViewController : MonoBehaviour
{
    public float AirplanePosY = 100;
    public float Maxpos = 497;
    public float Minpos = 157;
    public GameObject Plane;
    public DescendingPlane _DescendingPlane;


     public float GetCurrentLocation(){
        float distance = Maxpos - Minpos;
        float num = distance * AirplanePosY / 100;
        return num;
    }

    void MovePlane(){
        float num = GetCurrentLocation();
        // Debug.Log(num);
        Plane.GetComponent <RectTransform>().anchoredPosition = new Vector3(616.0f,Minpos + num,0);
    }
    // Start is called before the first frame update
    void Start()
    {
        AirplanePosY = _DescendingPlane.GetPlaneRatio();
        MovePlane();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
