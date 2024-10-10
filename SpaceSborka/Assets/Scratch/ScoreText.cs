using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 0;
    public Text scoreText;
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
