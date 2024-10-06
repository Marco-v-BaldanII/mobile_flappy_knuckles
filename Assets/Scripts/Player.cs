using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : PhysicBody
{

    public InputActionReference jump;
    private Rigidbody2D rigid;
    private Animator animator;

    private AudioSource audio;

    private int playerScore = 0;
    public TextMeshProUGUI scoreText;

    private bool hit = false;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        jump.action.started += Jump;
    }
    protected override void OnBodyEntered(HitBox box)
    {
        Debug.Log("on body entered");

        if (box.GetTag() == "kill" && rigid)
        { 
            audio.Play();

               if (!hit)
               {
                   hit = true;
                   Invoke("CallReStart", 1.8f);
               }

            animator.SetTrigger("hit");
            rigid.velocity = Vector3.zero;
            rigid.AddForce(new Vector2(2, 10), ForceMode2D.Impulse);  
            
        }
        else if (box.GetTag() == "cealing")
        {
            rigid.velocity = Vector3.zero;
            
        }
        else if (box.GetTag() == "point")
        {
            IncrementScore();
        }
    }

    protected override void OnBodyStay(HitBox box)
    {
        Debug.Log("on body stay");
        if (box.GetTag() == "cealing" && rigid)
        {
            rigid.velocity = Vector3.zero;
        }
    }

    protected override void OnBodyExit(HitBox box)
    {
        Debug.Log("on body exit");
    }


    public void Jump(InputAction.CallbackContext obj)
    {
        if (!hit && rigid)
        {
            Debug.Log("Jump");
            rigid.velocity = Vector3.zero;
            rigid.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
        }
    }

    private void CallReStart()
    {
        GameManager.instance.ReStartLevel();
    }
    private void OnDestroy()
    {
        jump.action.started -= Jump;
    }

    private void IncrementScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }
}
