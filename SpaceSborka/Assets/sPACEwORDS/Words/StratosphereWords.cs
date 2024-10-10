using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StratosphereWords : MonoBehaviour
{
    string s = AllWords.StratosphereWords;
    public List<string> words = new List<string>();
    string CurrentWord = "";
    // Start is called before the first frame update
    void Start()
    {
        string wordNow = "";
        for(int i = 0; i < s.Length; ++i)
        {
            if (s[i] == ' ')
            {
                words.Add(wordNow);
                wordNow = "";
            }
            else
            {
                wordNow += s[i];
            }
        }
        Debug.Log(words.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
