using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordMercury : MonoBehaviour
{
    string text1 = "Вы угадали 2 слова, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Меркурий — самая близкая планета к Солнцу. Таким образом, она вращается вокруг солнца быстрее, чем все другие планеты, поэтому римляне назвали ее в честь своего быстроногого бога-посланника. \r\n* Меркурий — самая маленькая в Солнечной системе. \r\n* Человечество существовать на планете Меркурий не сможет. Из-за того, что Меркурий находится  так близко к Солнцу, на освещённой стороне температура здесь может достигнуть +410 градусов. На стороне, которая Солнцем не освещается, температура опускается до – 210 градусов. \r\n* Поверхность Меркурия походит на поверхность Луны. Здесь также есть кратеры и уступы. Они образуются из-за того, что Меркурий часто сталкивается с астероидами и не может восстанавливаться после столкновения. \r\n";
    string text2 = "Вы угадали 5 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Вместо плотной атмосферы Меркурий обладает ультратонкой «экзосферой», состоящей из атомов, выброшенных с его поверхности солнечной радиацией, солнечным ветром и микрометеороидными ударами. \r\n* Из-за того, что у Меркурия нет атмосферы,планета не защищена от астероидов. На ней много кратеров от падений астероидов. Более 4 млрд лет назад на поверхность планеты упал большой астероид, в результате которого образовался бассейн шиpиной oкoлo 1550 килoмeтpoв. Кратер получил название Kaлopиc.\r\n* Время, за которое Меркурий совершает полный оборот вокруг солнца составляет 88 дней.\r\n* Сутки на Меркурии  — 176 земных дней \r\n";
    string text3 = "Вы угадали 8 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* У Меркурия нет естественных спутников. Ранее выдвигались теории о том, что они есть, однако потом было доказано, что их нет, как и у Венеры. \r\n* Ученые предполагают, что внутри Меркурия ядро жидкое. Это связано с тем, что у планеты слабое магнитное поле и тонкая атмосфера. \r\n* Во времена Древней Греции Меркурий утром называли Гермесом. В вечернее время суток его называли Аполлоном. Древнегреческие люди считали, что это абсолютно разные космические планеты. \r\n* Согласно одной из гипотез, считается, что ранее Меркурий был спутником Венеры. Однако произошло сильное столкновение, в результате которого Меркурий выбросило на орбиту. \r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    MercuryWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Mercury").GetComponent<MercuryWords>();
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
                if (cnt == 2)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 5)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 8)
                {
                    star3.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text3);

                }

                gList.Add(checkText.text);
                guessed.text = "";
                gList.Sort((x, y)=> x.Length.CompareTo(y.Length));
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
