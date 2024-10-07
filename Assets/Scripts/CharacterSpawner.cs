using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterSpawner : MonoBehaviour
{

    public GameObject Knuckles;
    public GameObject Tails;

    public Transform position;


    // Start is called before the first frame update
    void Start()
    {
        var character_id = PlayerPrefs.GetInt("character");


        if (character_id == 0)
        {
            Instantiate(Tails, position.position , Quaternion.identity);

        }
        else
        {
            Instantiate(Knuckles, position.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
