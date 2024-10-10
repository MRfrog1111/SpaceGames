using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordGravitation : MonoBehaviour
{
    string text1 = "Вы угадали 6 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Гравитация – сила притяжения между любыми объектами, имеющими массу. Гравитационная сила зависит от массы этих объектов и расстояния между ними. \r\n* Слово «гравитация» происходит от латинского «gravitas», что в переводе означает «тяжесть».\r\n* Сила гравитации позволяет Земле вращаться вокруг Солнца и удерживает все на поверхности планеты. Именно благодаря этой силе идет дождь, происходят приливы и отливы океанов. Сила гравитации Земли удерживает планету в сферической форме, а также сохраняет атмосферу вокруг планеты. \r\n";
    string text2 = "Вы угадали 14 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Никакой связи между гравитацией и весом объектов нет. Если сбросить с высоты пару предметов одинаковой формы, но разных по весу, они будут падать с одинаковым ускорением.\r\n* Чтобы преодолеть силу притяжения Земли, ракете необходимо разогнаться до 11,2 километров в секунду.\r\n* При отсутствующей силе тяжести пламя вокруг горящей спички или свечи распространяется во все стороны, а не тянется вверх.\r\n* Чисто теоретически человек может приспособиться к жизни на небесных телах, гравитация которых отличается от земной не более, чем в примерно три раза.\r\n";
    string text3 = "Вы угадали 22 словf, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Из-за более низкой силы тяжести люди, выросшие, например, на Марсе, будут выше обитателей Земли, но при этом они будут уступать им в физической силе.\r\n* Чисто теоретически человек может приспособиться к жизни на небесных телах, гравитация которых отличается от земной не более, чем в примерно три раза.\r\n* Чёрные дыры обладают настолько сильной гравитацией, что она притягивает даже свет.\r\n* Именно сила тяжести контролирует максимальную высоту гор на Земле.\r\n* Они не могут подняться выше 15 км, так как рискуют разрушиться под \tсобственной массой.";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    GravitationWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Gravitation").GetComponent<GravitationWords>();
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
                if (cnt == 6)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 14)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 22)
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
