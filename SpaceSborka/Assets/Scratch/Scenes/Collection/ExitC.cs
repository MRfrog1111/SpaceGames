using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitC : MonoBehaviour
{

    public void Press()
    {
        SceneManager.LoadScene("Menu");
    }
}
