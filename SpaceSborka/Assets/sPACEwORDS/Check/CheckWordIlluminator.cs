using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CheckWordIlluminator : MonoBehaviour
{
    string text1 = "Вы угадали 15 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы занли, что:\r\n* Иллюминатор обычно представляет собой круглое окно, используемое на корпусе корабля для пропуска света и воздуха. Хотя этот термин имеет морское происхождение, он также используется для описания круглых окон на бронетехнике, самолетах, автомобилях и даже космических кораблях.\r\n * В космонавтике иллюминаторы применяются на орбитальных станциях, космических кораблях и в спускаемых аппаратах.\r\n";
    string text2 = "Вы угадали 36 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы занли, что:\r\n* С одной стороны, иллюминаторы служат для защиты приборов и экипажа, находящихся внутри отсека, от воздействия внешней среды, с другой же – должны обеспечивать возможность работы различной оптической аппаратуры и визуальное наблюдение. \r\n* Основная часть иллюминатора – это, конечно, стекло. «Для космоса» используется не обычное стекло, а кварцевое. Для защиты членов экипажа от вредного воздействия ближнего ультрафиолетового излучения на стекла иллюминаторов, работающих с нестационарно установленными приборами, наносят специальные светоделительные покрытия.\r\n";
    string text3 = "Вы угадали 58 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы занли, что:\r\n* Иллюминатор – это не только стекла. Чтобы получить прочную и функциональную конструкцию, несколько стекол вставляют в обойму, выполненную из алюминиевого или титанового сплава.\r\n* Некоторые иллюминаторы имеют встроенные стеклоочистители для обеспечения четкого вида.\r\n* Крупнейшим космическим иллюминатором с 2010 года является центральный иллюминатор созданного в Италии модуля «Купол» американского сегмента МКС. Он изготовлен из кварцевого стекла толщиной 10 см, и имеет диаметр 80 см. \r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    IlluminatorWords aw;
    public Text checkText;
    GameObject[] bc;
    BtnClick bcNow;
    public Material grey;
    public Material yellow;

    GameObject star1;
    GameObject star2;
    GameObject star3;
    // Start is called before the first frame update
    void Start()
    {
        aw = GameObject.FindGameObjectWithTag("Illuminator").GetComponent<IlluminatorWords>();
        bc = GameObject.FindGameObjectsWithTag("BtnClick");
        check = this.GetComponent<Button>();
        check.onClick.AddListener(checkWord);

        star1 = GameObject.Find("Star1");
        star2 = GameObject.Find("Star2");
        star3 = GameObject.Find("Star3");
        star1.GetComponent<MeshRenderer>().material = grey;
        star2.GetComponent<MeshRenderer>().material = grey;
        star3.GetComponent<MeshRenderer>().material = grey;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void checkWord()
    {
        word = checkText.text;

        
        for (int i = 0; i < aw.words.Count; i++)
        {

            if (word.ToLower() == aw.words[i])
            {
                aw.words.RemoveAt(i);
                int cnt;
                int.TryParse(count.text, out cnt);
                cnt++;
                count.text = cnt.ToString();
                if (cnt == 15)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 36)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 58)
                {
                    star3.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text3);

                }
                gList.Add(checkText.text);
                guessed.text = "";
                gList.Sort((x, y) => x.Length.CompareTo(y.Length));
                for (int j = 0; j < gList.Count; ++j)
                {
                    Debug.Log(gList[j]);
                    guessed.text += gList[j];
                    if (j != gList.Count - 1)
                    {
                        guessed.text += " ";
                    }
                }
            }   
        }
        checkText.text = "";
        foreach (GameObject butt in bc)
        {
            bcNow = butt.GetComponent<BtnClick>();
            bcNow.btn.interactable = true;
        }
    }
}
