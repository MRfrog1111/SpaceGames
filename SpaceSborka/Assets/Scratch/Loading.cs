using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    bool timer = false;
    double time = 3.4;
  
    public GameObject LoadingScreen;
    void Start()
    {
        timer = true;
    }


    void Update()
    {
        if (timer)
        {
            time = time - 1 * Time.deltaTime;
            if (time <= 0)
            {
               LoadingScreen.gameObject.SetActive(false);
            }
        }
    }
}
