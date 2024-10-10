using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    float leftBound = 200f;
    float rightBound = 9700f;
    float upBound = 9700f;
    float downBound = 200f;
    
    int count;

    [SerializeField] GameObject stone;
    [SerializeField] GameObject copper;
    [SerializeField] GameObject uran;
    [SerializeField] GameObject niobium;
    [SerializeField] GameObject platinum;
    [SerializeField] GameObject aurum;
    void Start()
    {
        count = Random.Range(2376, 2500);
        for(int i = 0; i < count; i++)
        {
            Instantiate(stone, new Vector3(Random.Range(leftBound, rightBound), 60, Random.Range(downBound, upBound)), Quaternion.identity);
        }
        count = Random.Range(500, 701);
        for (int i = 0; i < count; i++)
        {
            Instantiate(copper, new Vector3(Random.Range(leftBound, rightBound ), 60, Random.Range(downBound, upBound )), Quaternion.identity);
        }
        count = Random.Range(250,401);
        for (int i = 0; i < count; i++)
        {
            Instantiate(uran, new Vector3(Random.Range(leftBound, rightBound), 60, Random.Range(downBound, upBound)), Quaternion.identity);
        }
        count = Random.Range(500, 601);
        for (int i = 0; i < count; i++)
        {
            Instantiate(niobium, new Vector3(Random.Range(leftBound, rightBound), 60, Random.Range(downBound, upBound)), Quaternion.identity);
        }
        count = Random.Range(400, 551);
        for (int i = 0; i < count; i++)
        {
            Instantiate(platinum, new Vector3(Random.Range(leftBound, rightBound), 60, Random.Range(downBound, upBound)), Quaternion.identity);
        }
        count = Random.Range(250, 401);
        for (int i = 0; i < count; i++)
        {
            Instantiate(aurum, new Vector3(Random.Range(leftBound, rightBound), 60, Random.Range(downBound, upBound)), Quaternion.identity);
        }
    }

   
    void Update()
    {
        
    }
}
