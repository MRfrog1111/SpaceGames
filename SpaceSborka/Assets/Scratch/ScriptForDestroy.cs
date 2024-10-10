   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptForDestroy : MonoBehaviour
{

    public GameObject Resource;
    bool inTrigger = false;
    bool index1 = false;
    float time = 3;
    //int score = 0;
    
    private ScoreText sT;

    void Start()
    { 
        sT = GameObject.Find("Switch").GetComponent<ScoreText>();
        DataHolder.score = 0;
       
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            index1 = true;
            if (inTrigger == true & index1 == true)
            {
                time = time - 1 * Time.deltaTime;
                if (time <= 0)
                {
                    index1 = false;
                    if (Resource.tag == "Stone")
                    {
                        DataHolder.score +=  10;
                        sT.scoreText.text = "Score: " + DataHolder.score.ToString();
                        //ScoreText.text = "Score: " + score.ToString();
                    }
                    else if (Resource.tag == "Copper")
                    {
                        DataHolder.score += 50;
                        sT.scoreText.text = "Score: " + DataHolder.score.ToString();
                    }
                    else if (Resource.tag == "Aurum")
                    {
                        DataHolder.score += 100;
                        sT.scoreText.text = "Score: " + DataHolder.score.ToString();
                    }
                    else if (Resource.tag == "Niobium")
                    {
                        DataHolder.score += 90;
                        sT.scoreText.text = "Score: " + DataHolder.score.ToString();

                    }
                    else if (Resource.tag == "Platinum")
                    {
                        DataHolder.score += 80;
                        sT.scoreText.text = "Score: " + DataHolder.score.ToString(); ;
                    }
                    else if (Resource.tag == "Uran")
                    {
                        DataHolder.score += 500;
                        sT.scoreText.text = "Score: " + DataHolder.score.ToString();
                    }
                    Destroy(Resource);
                }
            }
        }

    }




    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inTrigger = true;
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
/*
if (Resource.tag == "Stone")
{
    score = score + 10;
    ScoreText.text = "Score: " + score.ToString();
}
else if (Resource.tag == "Copper")
{
    score = score + 50;
    ScoreText.text = "Score: " + score.ToString();
}
else if (Resource.tag == "Aurum")
{
    score = score + 100;
    ScoreText.text = "Score: " + score.ToString();
}
else if (Resource.tag == "Niobium")
{
    score = score + 90;
    ScoreText.text = "Score: " + score.ToString();

}
else if (Resource.tag == "Platinum")
{
    score = score + 80;
    ScoreText.text = "Score: " + score.ToString();
}
else if (Resource.tag == "Uran")
{
    score = score + 500;
    ScoreText.text = "Score: " + score.ToString();
}*/