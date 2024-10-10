using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateController : MonoBehaviour
{ 
    
    
    
    private float x = 0.0f;
    private float y = 0.0f;

    void Update()
    {
        transform.eulerAngles = new Vector3(45f, x, y);
    }
}

