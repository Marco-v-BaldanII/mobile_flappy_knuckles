using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        GameManager.instance.gameOver.AddListener(Activate);
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
    public void ReTry()
    {
        GameManager.instance.ReStartLevel();
    }

    public void BackToTitle()
    {
        GameManager.instance.BackToMenu();
    }
    
}
