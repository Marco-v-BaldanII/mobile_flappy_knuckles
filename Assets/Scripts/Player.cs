using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PhysicBody
{

    public InputActionReference jump;
    private Rigidbody2D rigid;
    private Animator animator;

    private bool hit = false;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jump.action.started += Jump;
    }
    protected override void OnBodyEntered(HitBox box)
    {
        Debug.Log("on body entered");

        if (box.GetTag() == "kill")
        {

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
            Debug.Log("Jump");
            rigid.velocity = Vector3.zero;
            rigid.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
        }
    }

    private void CallReStart()
    {
        GameManager.instance.ReStartLevel();
    }

}
