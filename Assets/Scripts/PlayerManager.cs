using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class PlayerManager : MonoBehaviour
{
    private Vector3 leftPosition = new Vector3(-0.6f, 0.3f, -12.0f);
    private Vector3 rightPosition = new Vector3(2.0f, 0.3f, -12.0f);

    private Vector3 targetPosition;

    public float playerSpeed;

    public VisualEffect Righteffect;
    public VisualEffect Lefteffect;

    void Start(){
        targetPosition = transform.position;
    }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * playerSpeed);

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            OnClickLeftButton();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            OnClickRightButton();
        }
    }

    public void OnClickLeftButton(){
        targetPosition = leftPosition;
        Lefteffect.Play();
    }

    public void OnClickRightButton(){
        targetPosition = rightPosition;
        Righteffect.Play();
    }
}
