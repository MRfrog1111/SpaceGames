using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class DataHolder
{
    private static Image ResultImage;
    private static int Score;
    public static int score
    {
        get { return Score; }
        set { Score = value; }
    }
    public static Image resultImage
    {
        get { return ResultImage; }
        

    }

}
