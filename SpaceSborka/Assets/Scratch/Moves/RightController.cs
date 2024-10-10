using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour
{
    public float speed = 0.1f;
    int index;
    public GameObject player;
    public GameObject On;
    public GameObject Off;

    void Update()
    {
        if(index == 1)
        {
            player.transform.Rotate(0, speed, 0);
        }
        if(index == 0)
        {
            
        }
    }
    public void ON()
    {
        index = 1;
        On.gameObject.SetActive(false);
        Off.gameObject.SetActive(true);
    }
    public void OFF()
    {
        index = 0;
        On.gameObject.SetActive(true);
        Off.gameObject.SetActive(false);
    }
}
