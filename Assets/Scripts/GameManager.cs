using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{


    public static GameManager instance;

    private List<HitBox> subscribers; // List for the hitboxes to subscribe to the event

    public RetryMenu retryMenu;

    public UnityEvent gameOver;

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Subscribe(HitBox box)
    {
        if (subscribers == null)
        {
            subscribers = new List<HitBox>();
        }
        subscribers.Add(box);
    }

    public void Unsubscribe(HitBox box)
    {
        if (subscribers != null && subscribers.Contains(box))
        {
            subscribers.Remove(box);
        }
    }
    private void FixedUpdate()
    {
        for (int _index = 0; _index < subscribers.Count; _index++)
        {
            for (int index = subscribers.Count - 1; index >= 0; index--)
            {
                HitBox box = subscribers[index];
                HitBox box2 = subscribers[_index];



                CheckCollision(box, box2);

            }
        }
    }

    private void CheckCollision(HitBox box, HitBox box2)
    {
        bool alreadyColliding = false;

        if (box != box2)
        {

            if (box.colliding.Contains(box2))
            {
                alreadyColliding = true;
            }

            var x1 = box.GetPos().x;  var y1 = box.GetPos().y;
            var x2 = box2.GetPos().x; var y2 = box2.GetPos().y;
            var w1 = box.transform.lossyScale.x; var h1 = box.transform.lossyScale.x;
            var w2 = box2.transform.lossyScale.x; var h2 = box2.transform.lossyScale.y;

            var ty1 = box.GetTopPos().y;
            var ty2 = box2.GetTopPos().y;

            //((y2 < y1) &&  (y1 < y2 + h2) && (y1 + h1 > y2))

            if ((x1 < x2 + w2) && (x1 + w1 > x2) &&(  (y2 < ty1 && y1 < ty2)  || (y1 < ty2 && ty1 > y2) )) /* If the hitboxes are overlapping */
            {
                 if (alreadyColliding)
                {
                    box.body_stay.Invoke(box2);  /* They are still colliding */
                }
                else
                {
                    box.body_enter.Invoke(box2); /* They have started to collide */
                    box.colliding.Add(box2); /* List tracks that these 2 bodies are already colliding now */
                }
            }
            else if (alreadyColliding) /* They are no longer colliding */
            {
                box.body_exit.Invoke(box2); 
                box.colliding.Remove(box2); 
            }

            // The squares are not overlapping
        }

    }


    public void ReStartLevel()
    {
        subscribers.Clear();
        SceneManager.LoadScene(0);
    }

    public void BackToMenu()
    {
        subscribers.Clear();
        SceneManager.LoadScene(3);
    }

    public void RetryMenu()
    {
        gameOver.Invoke();

        //if (retryMenu)
        //{
        //    retryMenu.gameObject.SetActive(true);
        //}
    }
}
