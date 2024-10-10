using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AboutMoonRover : MonoBehaviour
{

    private static AboutMoonRover instance;

    public GameObject Template;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public static void ShowMassage()
    {
        GameObject aboutMoonRover = Instantiate(instance.Template);

        Transform canvas = aboutMoonRover.transform.Find("Canvas");
        Transform panel = canvas.transform.Find("Panel");

        Button ok = panel.Find("ok").GetComponent<Button>();
        ok.onClick.AddListener(() =>
        {
            Destroy(aboutMoonRover);
        });
    }
}
