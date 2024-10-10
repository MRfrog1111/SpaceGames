using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordUniverse : MonoBehaviour
{
    string text1 = "Вы угадали 3 слова, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Вселенная — термин, который обычно означает весь пространственно-временной континуум, в котором мы существуем вместе со всеми формами энергии и материи внутри него — планетой, звёздами, галактиками и межгалактическим пространством . \r\n\r\n* Наблюдаемая Вселенная простирается по меньшей мере на 93 миллиарда световых лет. Для сравнения, диаметр типичной галактики составляет всего 30 000 световых лет, а типичное расстояние между двумя соседними галактиками составляет 3 миллиона световых лет. Например, Млечный Путь имеет диаметр около 100 000 световых лет, а ближайшая Галактика Андромеды находится на расстоянии 2,5 миллиона световых лет.\r\n";
    string text2 = "Вы угадали 8 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* В наблюдаемой Вселенной насчитывается, вероятно, 100 миллиардов галактик. В самых маленьких галактиках около 10 миллионов звёзд, а в самых больших — несколько триллионов звёзд.\r\n* Вселенная образовалась примерно 13.8 миллиардов лет назад в результате Большого взрыва. \r\n* Общая масса-энергия наблюдаемой Вселенной состоит на 4,9 % из обычной материи, на 26,8 % из тёмной материи и на 68,3 % из темной энергии. \r\n* Черные дыры - одно из самых загадочных и удивительных явлений в космосе. Они имеют настолько сильное гравитационное поле, что ничто, даже свет, не может покинуть их поверхность\r\n";
    string text3 = "Вы угадали 12 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Вселенная постоянно расширяется. Расширение вселенной можно рассматривать как \"растягивание\" пространства между объектами. Это означает, что галактики отдаляются друг от друга, подобно точкам на поверхности надувного шара, когда шар надувается. \r\n* Невозможно в прямом смысле сравнить расстояние между галактиками сегодня и десять лет назад. Но что мы действительно можем увидеть, так это изменение красного смещения: так называют явление, при котором длина волны видимого света, испускаемого наблюдаемым объектом, увеличивается для наблюдателя. Чем дальше от нас галактика и чем быстрее она удаляется, тем краснее становится наблюдаемый спектр.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    UniverseWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Universe").GetComponent<UniverseWords>();
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
                if (cnt == 8)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 12)
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
