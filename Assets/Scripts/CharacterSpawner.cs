using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterSpawner : MonoBehaviour
{

    public GameObject Knuckles;
    public GameObject Tails;

    public Transform position;

    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
        var character_id = PlayerPrefs.GetInt("character");


        if (character_id == 0)
        {
            var player = Instantiate(Tails, position.position , Quaternion.identity);
            var tails = player.GetComponent<Tails>();
            if (tails)
            {
                tails.scoreText = scoreText;
            }

        }
        else
        {
            var player = Instantiate(Knuckles, position.position, Quaternion.identity);
            var knuckles = player.GetComponent<Player>();
            if (knuckles)
            {
                knuckles.scoreText = scoreText;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
