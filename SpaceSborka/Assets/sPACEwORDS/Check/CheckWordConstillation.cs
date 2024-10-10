using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordConstillation : MonoBehaviour
{
    string text1 = "Вы угадали 3 слова, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* В современной астрономии выделяется 88 созвездий. Часть из них можно увидеть только из Северного полушария(Большая Медведица, Малая Медведица,Кассиопея, Цефей, Дракон и др.), а часть — из Южного(Южный Крест, Скорпион, Стрелец, Змееносец и др.).\r\n* Звезды, визуально входящие в одно созвездие, могут на самом деле быть расположены в сотнях и тысячах световых лет друг от друга, одни дальше, другие ближе. Но с Земли кажется, что они находятся рядом.\r\n* 48 из вышеупомянутых 88 созвездий были описаны еще Птолемеем, древнегреческим ученым и философом, который составил свой атлас звездного неба около 2200 лет назад.\r\n";
    string text2 = "Вы угадали 7 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Звезды и галактики отнюдь не неподвижны, поэтому созвездия тоже постепенно меняются и искажаются. Но в пределах жизни нескольких поколений людей это незаметно.\r\n* В зависимости от времени года мы можем наблюдать на небе разные созвездия, так как Земля движется вокруг Солнца, а не стоит на месте.\r\n* Некоторые созвездия входят в состав других. Так, в состав Геркулеса входит 19 созвездий, а в состав Большой Медведицы — 10.\r\n* В созвездии Водолея располагается самая холодная из известных нам звезд, температура ее поверхности составляет лишь около 2700 градусов. От Солнца ее отделяет 900 световых лет.\r\n";
    string text3 = "Вы угадали 10 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Созвездие Близнецов интересно тем, что именно благодаря его звёздам астроном Гершель в 18-м веке сумел с помощью телескопа открыть планету Уран.\r\n* В созвездие Большой Медведицы входят не только звезды. Две яркие точки в его составе — это целые галактики, но они находятся так далеко от нас, что их действительно можно спутать со звездами.\r\n* Солнце проходит созвездие Скорпиона быстрее, чем все остальные — всего за неделю.\r\n* Древние греки называли созвездие Козерога «рыба-коза».\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    ConstillationWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Constillation").GetComponent<ConstillationWords>();
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
                if (cnt == 3)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 7)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 10)
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
