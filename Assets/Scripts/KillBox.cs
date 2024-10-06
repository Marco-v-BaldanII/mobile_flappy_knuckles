using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : PhysicBody
{
    private void Awake()
    {
        
    }
    protected override void OnBodyEntered(HitBox box)
    {
        Debug.Log("on body entered");
    }

    protected override void OnBodyStay(HitBox box)
    {
        Debug.Log("on body stay");
    }

    protected override void OnBodyExit(HitBox box)
    {
        Debug.Log("on body exit");
    }

}
