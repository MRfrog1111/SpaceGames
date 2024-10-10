using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordGalaxy : MonoBehaviour
{
    string text1 = "Вы угадали 5 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* На ночном небе невооружённым взглядом можно разглядеть всего 4 галактики – Андромеду, M33 и два Магеллановых облака, Большое и Малое.\r\n* Из-за постоянного расширения Вселенной многие галактики постоянно удаляются от Млечного Пути со скоростью, исчисляемой сотнями тысяч километров в секунду. \r\n* Самая большая галактика, известная учёным, называется IC 1101. Она в 2000 раз массивнее Млечного Пути и в 60 раз крупнее. Если бы она находилась на его месте, она поглотила бы все четыре ближайшие к нам галактики.\r\n* Ближайшая к нам галактика – Андромеда. Нас от неё отделяет дистанция в 2,52 млн световых лет.\r\n* К 1990 году астрономам было известно лишь около 30 других галактик.\r\n* Исследование орбитального телескопа “Хаббл” показало, что на 1/30.000.000 (одной тридцатимиллионной) видимого неба находится в среднем 2000 галактик.\r\n";
    string text2 = "Вы угадали 11 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* У некоторых галактик есть галактики-спутники. Для Млечного Пути таковыми являются Большое и Малое Магеллановы облака.\r\n* Крупные галактики могут пожирать своих соседей поменьше, поглощая их звёзды и втягивая их в себя. Вышеупомянутая IC 1101, скорее всего, именно так и достигла столь значительных размеров.\r\n* Около 10% всей наблюдаемой Вселенной приходится на плоскую суперструктуру под названием  Великая стена Геркулес — Северная Корона. В длину стена достигает примерно 10 млрд световых лет! Учёные утверждают, что она состоит из огромного числа галактик и галактических скоплений.\r\n* Активные галактические ядра на начальном этапе развития называются квазарами. Это самые яркие объекты во Вселенной\r\n";
    string text3 = "Вы угадали 18 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Примерно через 4,5 млрд лет Млечный Путь и Андромеда столкнутся. Последствия такого столкновения могут быть разными – одни учёные верят, что галактики просто пройдут друг сквозь друга, другие же полагают, что Андромеда поглотит своего меньшего соседа.\r\n* В нашей собственной Галактике появляется среднем по 10 новых звёзд в год.\r\n* Галактика I Zwicky 18 – самая молодая из известных нам. Её возраст составляет порядка 500 млн лет.\r\n* Исследуя другие галактики, мы видим их такими, какими они были миллионы и миллиарды лет назад. Можно не сомневаться, что некоторых из них уже нет.\r\n* У галактик, как и у звёзд, есть свои зоны обитаемости. Вблизи центра звёзды в них расположены слишком плотно, а пространство пронизано жёсткой радиацией. А слишком далеко от него состав звёзд считается неподходящим для потенциального зарождения жизни на гипотетических планетах.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    GalaxyWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Galaxy").GetComponent<GalaxyWords>();
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
                if (cnt == 5)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 11)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 18)
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
