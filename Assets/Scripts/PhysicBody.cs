using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBody : MonoBehaviour
{

    private HitBox hitBox;

    // Start is called before the first frame update
    private void Start()
    {
        hitBox = GetComponentInChildren<HitBox>();
        if (hitBox != null)
        {
            hitBox.Attach(OnBodyEntered);
        }

    }

    protected virtual void OnBodyEntered()
    {
        Debug.Log("on body entered");
    }
}
