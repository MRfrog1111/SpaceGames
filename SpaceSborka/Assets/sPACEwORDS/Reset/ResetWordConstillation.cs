using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetWordConstillation : MonoBehaviour
{
    Button reset;
    ConstillationWords aw;
    public Text checkText;
    GameObject[] bc;
    BtnClick bcNow;
    // Start is called before the first frame update
    void Start()
    {
        bc = GameObject.FindGameObjectsWithTag("BtnClick");
        aw = GameObject.FindGameObjectWithTag("Constillation").GetComponent<ConstillationWords>();
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
