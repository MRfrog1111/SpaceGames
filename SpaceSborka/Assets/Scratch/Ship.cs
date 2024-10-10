using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    bool inTrigger = false;
    bool index1 = false;
    float time = 3;
    public Image ResultImage;
    public Text ResultTxt1;
    public Text ResultTxt2;
    public Text ResultTxt3;
    public Text TotalyResult;
    void Start()
    {
        ResultImage.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            index1 = true;
            if (inTrigger == true & index1 == true)
            {
                time = time - 1 * Time.deltaTime;
                if (time <= 0)
                {
                    time = 1;
                    ResultImage.gameObject.SetActive(true);
                    time = time - 1 * Time.deltaTime;
                    if (time <= 0)
                    {
                        time = 1;
                        ResultTxt1.gameObject.SetActive(true);
                        time = time - 1 * Time.deltaTime;
                        if (time <= 0)
                        {
                            time = 1;
                            ResultTxt2.gameObject.SetActive(true);
                            time = time - 1 * Time.deltaTime;
                            if (time <= 0)
                            {
                                time = 1;
                                ResultTxt3.gameObject.SetActive(true);
                                time = time - 1 * Time.deltaTime;
                                if (time <= 0)
                                {
                                    TotalyResult.gameObject.SetActive(true);
                                }
                            }
                        }
                    }
                    index1 = false;
                   
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
