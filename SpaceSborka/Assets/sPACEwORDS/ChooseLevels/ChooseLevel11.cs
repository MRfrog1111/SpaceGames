using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel11 : MonoBehaviour
{
    Button level;
    // Start is called before the first frame update
    void Start()
    {
        level = this.GetComponent<Button>();
        level.onClick.AddListener(OpenStratosphere);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenStratosphere()
    {
        SceneManager.LoadScene("WeightlessnessScene");
    }
}
