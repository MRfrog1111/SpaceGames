                        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject Player;
    private Vector3 follow;

    void Start()
    {
        follow = transform.position - Player.transform.position;
    }

    void Update()
    {
        transform.position = Player.transform.position + follow;
    }
}

 