using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public GameObject Pipe;
    public float SpawnRate = 2.0f;
    private float Timer = 0;
    public float heightOffset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < SpawnRate)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            Timer = 0;
        }
        
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Pipe, new Vector2(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }

}
