using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{


    public static GameManager instance;

    private List<HitBox> subscribers; // List for the hitboxes to subscribe to the event

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

    private void FixedUpdate()
    {
        for (int _index = 0; _index < subscribers.Count; _index++)
        {
            for (int index = subscribers.Count - 1; index >= 0; index--)
            {
                if (index != _index) /* If both hitboxes aren't the same */
                {

                    var x1 = subscribers[index].GetPos().x; ; var y1 = subscribers[index].GetPos().y;
                    var x2 = subscribers[_index].GetPos().x; var y2 = subscribers[_index].GetPos().y;
                    var w1 = subscribers[index].transform.localScale.x; var h1 = subscribers[index].transform.localScale.x;
                    var w2 = subscribers[_index].transform.localScale.x; var h2 = subscribers[_index].transform.localScale.y;

                    if ((x1 < x2 + w2) && (x1 + w1 > x2) && (y1 < y2 + h2) && (y1 + h1 > y2)) /* If the hitboxes are overlapping */
                    {
                        HandleEventCall(subscribers[index]);
                        HandleEventCall(subscribers[_index]);
                    }
                    // The squares are overlapping
                    else
                    {

                    }
                    // The squares are not overlapping
                }

            }
        }
    }

    private void HandleEventCall(HitBox c1 ) /*Check what kind of collision is ocurring*/
    {
        if (c1 )
        {
            if (c1.state == HitBox.COLLIDING_STATE.NONE)
            {
                c1.body_enter.Invoke();
                c1.state = HitBox.COLLIDING_STATE.ENTERED;
            }
            else if (c1.state == HitBox.COLLIDING_STATE.ENTERED || c1.state == HitBox.COLLIDING_STATE.STAY)
            {
                c1.body_stay.Invoke();
                c1.state = HitBox.COLLIDING_STATE.STAY;
            }

        }
    }

}
