using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cealing : PhysicBody
{

    protected override void OnBodyEntered(HitBox box)
    {
        Debug.Log("on body entered");
    }

    protected override void OnBodyStay(HitBox box)
    {
        Debug.Log("on body stay");

        if (box.GetTag() == "player")
        {

            Rigidbody2D playerBody = box.GetComponentInParent<Rigidbody2D>();
            if (playerBody)
            {
                playerBody.velocity = Vector2.zero;
            }
        }

    }

    protected override void OnBodyExit(HitBox box)
    {
        Debug.Log("on body exit");
    }

}