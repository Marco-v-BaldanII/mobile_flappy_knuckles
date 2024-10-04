using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HitBox : MonoBehaviour
{
    const float SCALE_RATIO = 10.0f;

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
                Debug.Log($"Width set to: {width}");
            }
            else
            {
                width = 1;
                Debug.LogWarning("Width must be greater than 0.");
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
                Debug.Log($"Height set to: {height}");
            }
            else
            {
                height = 1;
                Debug.LogWarning("Height must be greater than 0.");
            }
        }
    }


    private Vector2 scale = new Vector2(1, 1);

    private Transform shape;

    // Start is called before the first frame update
    void Start()
    {
        shape = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _width = width;

        if (shape != null)
        {
            scale.x = width / SCALE_RATIO; scale.y = height / SCALE_RATIO;
            shape.localScale = scale;
        }
        else
        {
            shape = GetComponentInChildren<Transform>();
        }

        Debug.Log(width);
    }
}
