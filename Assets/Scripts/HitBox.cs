using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class HitBox : MonoBehaviour
{

    public UnityEvent<HitBox> body_enter;
    public UnityEvent<HitBox> body_exit;
    public UnityEvent<HitBox> body_stay;

    const float SCALE_RATIO = 10.0f;

    public List<HitBox> colliding = new List<HitBox>();

    public int width = 10;
    private int _width
    {
        get
        {
            return width;
        }
        set
        {
            if (value > 0)
            {
                width = value;

            }
            else
            {
                width = 1;

            }
        }
    }
    public int height = 10;

    private int _height
    {
        get
        {
            return height;
        }
        set
        {
            if (value > 0)
            {
                height = value;

            }
            else
            {
                height = 1;

            }
        }
    }


    private Vector2 scale = new Vector2(1, 1);

    private Vector2 top_position = new Vector2(0, 0);

    private Transform shape;

    // Start is called before the first frame update
    void Start()
    {
        shape = GetComponentInChildren<Transform>();
        UpKeep();
        GameManager.instance.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        UpKeep();

    }

    public Vector2 GetPos() { return top_position; }


    private void UpKeep()
    {
        _width = width;
        top_position = new Vector2(transform.position.x - (scale.x / 2), transform.position.y + (scale.y / 2));
        Debug.DrawLine(transform.position, top_position, Color.red);

        if (shape != null)
        {
            scale.x = width / SCALE_RATIO; scale.y = height / SCALE_RATIO;
            shape.localScale = scale;
        }
        else
        {
            shape = GetComponentInChildren<Transform>();
            scale.x = width / SCALE_RATIO; scale.y = height / SCALE_RATIO;
            shape.localScale = scale;
        }
    }

    public void Attach( UnityAction<HitBox> enter, UnityAction<HitBox> stay, UnityAction<HitBox> exit )
    {
        body_enter.AddListener(enter);
        body_exit.AddListener(exit);
        body_stay.AddListener(stay);
    }

}
