using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public GameObject player;
    public float high = 100;
   
    void LateUpdate()
    {
        transform.position = player.transform.position + Vector3.up * high; 
    }
}
