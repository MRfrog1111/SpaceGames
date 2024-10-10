using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour
{
    public Button btn;
    public Text wrd;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(AddSymbol);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddSymbol()
    {
        Button btn = this.GetComponent<Button>();
        wrd.text += this.GetComponentInChildren<Text>().text;
        btn.interactable = false;
    }
}
