using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AboutIlluminator : MonoBehaviour
{

    private static AboutIlluminator instance;

    public GameObject Template;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public static void ShowMassage(string text)
    {
        GameObject aboutIlluminator = Instantiate(instance.Template);

        Transform canvas = aboutIlluminator.transform.Find("Canvas");
        Transform panel = canvas.transform.Find("Panel");
        Text about = panel.Find("about").GetComponent<Text>();
        about.text = text;  
        Button ok = panel.Find("ok").GetComponent<Button>();
        ok.onClick.AddListener(() =>
        {
            Destroy(aboutIlluminator);
        });
    }
}
