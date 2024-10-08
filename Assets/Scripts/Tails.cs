using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tails : PhysicBody
{

    public InputActionReference jump;
    private Rigidbody2D rigid;
    private Animator animator;

    private bool hit = false;

    private AudioSource audio;

    private int playerScore = 0;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();


        jump.action.started += Jump;
        jump.action.canceled += StopFlying;
    }
    protected override void OnBodyEntered(HitBox box)
    {
        Debug.Log("on body entered");

        if (box.GetTag() == "kill")
        {
            audio.Play();

            GameManager.instance.CheckScore(Convert.ToInt32(scoreText.text));

            if (!hit)
            {
                hit = true;
                Invoke("CallReStart", 2.5f);
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
        if (box.GetTag() == "cealing")
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
        if (!hit)
        {
            StartCoroutine(Fly());
        }
    }

    private IEnumerator Fly()
    {
        while (!hit) 
        {
            rigid.velocity = new Vector2(0, 3);
            yield return null;
        }
    }

    public void StopFlying(InputAction.CallbackContext obj)
    {
        StopAllCoroutines();
    }

    private void CallReStart()
    {
        GameManager.instance.RetryMenu();
    }

    private void OnDestroy()
    {
        jump.action.started -= Jump;
        jump.action.canceled -= StopFlying;
    }

    private void IncrementScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }
}
