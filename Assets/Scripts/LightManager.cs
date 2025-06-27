using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    [SerializeField] private int num = 0;
    private Renderer rend;
    private float alfa = 0;
    public Button Left;
    public Button Right;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(rend.material.color.a <= 0)){
            rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,alfa);
        }
        // if(num == 1){
        //     if(Input.GetKeyDown(KeyCode.A)){
        //         colorChange();
        //     }
        // }

        // if(num == 2){
        //     if(Input.GetKeyDown(KeyCode.D)){
        //         colorChange();
        //     }
        // }

        alfa -= Speed * Time.deltaTime;
    }

    void colorChange(){
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,alfa);
    }

    public void OnClickL(){
        if(num == 1){
        // colorChange();
        }
    }

    public void OnClickR(){
        if(num == 2){
            // colorChange();
        }
    }
}
