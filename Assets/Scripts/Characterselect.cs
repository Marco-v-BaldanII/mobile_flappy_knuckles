using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Characterselect : MonoBehaviour
{


    float timer = 0.1f;

    private int index = 0;
    public SpriteRenderer[] characters;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && timer < 0)
        {
            timer = 0.1f;

            ChangeIndex(-1);

        }

        if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.RightArrow)) && timer < 0)
        {
            timer = 0.1f;

            ChangeIndex(1);


        }


        if (Input.GetKeyDown(KeyCode.Space))
        {

            PlayerPrefs.SetInt("character", index);
            SceneManager.LoadScene("SampleScene");

        }

    }

    private void ChangeIndex(int amount)
    {
        characters[index].color = Color.gray;

        index += amount;
        index %= characters.Length ;
        if (index == -1) { index = characters.Length - 1; }


        characters[index].color = Color.white;
        transform.position = new Vector3(characters[index].transform.position.x, transform.position.y, transform.position.z);

    }
}
