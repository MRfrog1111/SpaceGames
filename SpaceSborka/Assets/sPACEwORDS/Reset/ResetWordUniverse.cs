using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetWordUniverse : MonoBehaviour
{
    Button reset;
    UniverseWords aw;
    public Text checkText;
    GameObject[] bc;
    BtnClick bcNow;
    // Start is called before the first frame update
    void Start()
    {
        bc = GameObject.FindGameObjectsWithTag("BtnClick");
        aw = GameObject.FindGameObjectWithTag("Universe").GetComponent<UniverseWords>();
        reset = this.GetComponent<Button>();
        reset.onClick.AddListener(resetWord);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetWord()
    {
        checkText.text = "";
        foreach (GameObject butt in bc)
        {
            bcNow = butt.GetComponent<BtnClick>();
            bcNow.btn.interactable = true;
        }
    }
}
