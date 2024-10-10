using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next13 : MonoBehaviour
{
    Button level;
    // Start is called before the first frame update
    void Start()
    {
        level = this.GetComponent<Button>();
        level.onClick.AddListener(OpenIlluminator);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OpenIlluminator()
    {
        SceneManager.LoadScene("IlluminatorScene");
    }
}
