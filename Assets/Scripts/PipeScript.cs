using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeScript : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    private float deathZone = -45;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0,0,-0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deathZone)
        {
            Debug.Log("Pipe Killed");

            HitBox[] hitboxes = GetComponentsInChildren<HitBox>();

            foreach (HitBox hitbox in hitboxes)
            {
                hitbox.CleanupAndDestroy();
            }

            Destroy(gameObject);

        }
    }
}
