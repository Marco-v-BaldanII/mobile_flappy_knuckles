using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{

    public Transform[] backgrounds;

    private Vector3 parallaxMovement;

    private float spawnPos;

    public float speed = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        parallaxMovement = new Vector3(speed, 0, 0);

        spawnPos = backgrounds[1].position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform background in backgrounds)
        {
            background.position += parallaxMovement;

            if (background.transform.localPosition.x < -28.65)
            {
                background.position = new Vector3(spawnPos, background.position.y, background.position.z);
            }
        }
    }
}
