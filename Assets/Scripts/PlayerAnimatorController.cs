using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator anim;
    private bool position;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        position = true;
        AttackComebackEvent();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            OnClickLeftButton();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            OnClickRightButton();
        }
        
    }
    public void AttackComebackEvent(){
        Debug.Log("りせっと");
        anim.SetBool("attack", false);
        anim.SetBool("left", false);
        anim.SetBool("right", false);
    }

    // public void RightComebackEvent(){
    //     anim.SetBool("right", false);
    // }

    // public void LeftComebackEvent(){
    //     anim.SetBool("left", false);
    // }

    public void OnClickLeftButton(){
        if(position == true){
            anim.SetBool("attack", true);
            Invoke("AttackComebackEvent",0.4f);
        }
        
        if(position == false){
            position =true;
            anim.SetBool("left", true);
            StartCoroutine(PlayAttackAfterDelay(0.1f));
        }
    }

    public void OnClickRightButton(){
        if(position == false){
            anim.SetBool("attack", true);
            Invoke("AttackComebackEvent",0.4f);
        }

        if(position == true){
            position = false;
            anim.SetBool("right", true);
            StartCoroutine(PlayAttackAfterDelay(0.1f));
        }
    }

    private IEnumerator PlayAttackAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        anim.SetBool("attack", true);
        Invoke("AttackComebackEvent",0.4f);
    }
}


    // private Vector3 leftPosition = new Vector3(-4.1f, 0.0f, -0.65f);
    // private Vector3 rightPosition = new Vector3(4.1f, 0.0f, -0.65f);