using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Rules : MonoBehaviour
{
    Button rules;
    string text = "В каждом уровне вам представлено слово так или иначе связанное с космической тематикой. Из букв этого слова нужно составить слова, дважды одну и ту же букву использовать нельзя. Все слова должны быть существительными в именительном падеже, не засчитываются аббревиатуры(ООН, ГИБДД, РАН и т.п.), Имена собственные (названия стран, городов, рек, брендов и т.д.).\r\n\r\nЧтобы проверить слово, нажмите кнопку “Проверить”, тогда слово, если слово существует, оно  будет добавлено в список угаданных, который виден на экране. Если вы хотите заново ввести слово, нажмите кнопку “Сброс”\r\n\r\nЕсли игрок угадывает 10% слов, он получает 1 звезду, 25% - 2 звезды, 40% - 3 звезды. После каждой новой звезды выводятся занимательные факты о космическом объекте или явлении. \r\n";
    // Start is called before the first frame update
    void Start()
    {
        rules = this.GetComponent<Button>(); 
        rules.onClick.AddListener(() => { AboutIlluminator.ShowMassage(text); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
