using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[ExecuteInEditMode]
public class PhysicBody : MonoBehaviour
{

    private HitBox hitBox;

    // Start is called before the first frame update
    private void Start()
    {
        hitBox = GetComponentInChildren<HitBox>();
        if (hitBox != null)
        {
            hitBox.Attach(OnBodyEntered, OnBodyStay, OnBodyExit);
        }

    }

    private void Update()
    {
        if (hitBox == null)
        {
            Debug.LogWarning("Warning ! Object of class Physic body must have a hitbox as child !");
            hitBox = GetComponentInChildren<HitBox>();
        }
    }

    protected virtual void OnBodyEntered(HitBox box)
    {
        Debug.Log("on body entered");
    }

    protected virtual void OnBodyStay(HitBox box)
    {
        Debug.Log("on body stay");
    }

    protected virtual void OnBodyExit(HitBox box)
    {
        Debug.Log("on body exit");
    }

}
