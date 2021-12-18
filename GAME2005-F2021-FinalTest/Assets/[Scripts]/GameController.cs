using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CubeBehaviour[] boxList;
    public PlayerBehaviour[] PlayerList;


    // Start is called before the first frame update
    void Start()
    {
        boxList = FindObjectsOfType<CubeBehaviour>();
        PlayerList = FindObjectsOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < boxList.Length; i++)
        {
            for (int j = 0; j < PlayerList.Length; j++)
            {
                if (i != j)
                {
                    CheckPlayerToBox(boxList[i], PlayerList[j]);
                }
            }
        }
    }


    public static void CheckPlayerToBox(CubeBehaviour a, PlayerBehaviour b)
    {
        if ((a.min.x <= b.max.x && a.max.x >= b.min.x) &&
           (a.min.y <= b.max.y && a.max.y >= b.min.y) &&
           (a.min.z <= b.max.z && a.max.z >= b.min.z))
        {
            if (!b.contacts.Contains(a))
            {
                b.contacts.Add(a);
                Debug.Log("BoxBox");    
                a.gameObject.GetComponent<CubeBehaviour>().isColliding = true;
                a.gameObject.GetComponent<CubeBehaviour>().AddForce(b.gameObject.GetComponent<PlayerBehaviour>().direction);

            }
        }
        else
        {
            if (b.contacts.Contains(a))
            {
                b.contacts.Remove(a);
                b.isColliding = false;
                a.isColliding = false;

            }
        }
    }


   

}
