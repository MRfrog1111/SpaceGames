using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordSatelite : MonoBehaviour
{
    string text1 = "Вы угадали 5 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* В Солнечной системе есть две планеты, у которых спутника нет совсем. Речь идет о Меркурии и Венере.\r\n* У Земли есть несколько небольших непостоянных спутников. Например, астероид 2006-RH вращается вокруг нашей звезды, но несколько раз за столетие приближается к земной орбите.\r\n* Самый крохотный спутник в Солнечной системе — крошечный астероид Дактиль, диаметр которого всего 1,5 километра. Он вращается вокруг другого, более крупного астероида Иды.\r\n* Спутниками владеют не только настоящие планеты, но и карликовые. Есть они у Эриды, Хаумеа и Плутона, который еще двадцать лет назад считался девятой планетой Солнечной системы.\r\n";
    string text2 = "Вы угадали 12 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Ганимед — спутник Юпитера, обладающий самыми большими размерами среди всех спутников планет Солнечной системы.\r\n* Янус и Эпиметей — два удивительных спутника Сатурна. Были времена, когда они представляли собой единый спутник, но потом раскололись. Но раз в четырехлетку они подходят друг к другу очень близко и потом меняются своими орбитами.\r\n* У Юпитера — 79 спутников, больше чем у любой другой планеты Солнечной системы. \r\n* Спутник Сатурна Энцелад выбрасывает в космическое пространство огромное количество льда и они образуют одно из колец планеты.\r\n* Некоторые астрономы считают, что жизнь в нашей Солнечной системе есть не только на Земле, но и на одном из многочисленных спутников Юпитера или Сатурна. Ученых в первую очередь интересуют такие спутники, как Энцелад и Европа с их океанами, скрытыми толщей льда, где возможно могут обитать живые существа.\r\n";
    string text3 = "Вы угадали 20 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Жидкие водоемы есть не только на Земле, но и на Титане — сатурнианском спутнике. Но жидкость состоит не из привычной нам воды, а этана и метана.\r\n* На юпитерианском спутнике Европе воды почти в три раза больше, чем на нашей планете.\r\n* Планета Меркурий меньше, чем некоторые спутники планет, например, меньше Ганимеда и Титана.\r\n* На Ио (самый близкий к Юпитеру спутник) есть более четырехсот вулканов. Они действующие, извергают много ядовитых веществ и представляют собой настоящий ад.\r\n* Астрономы считают, что земляне скорее колонизируют не Марс, а спутник Титан, у которого очень плотная атмосфера, защищающая от радиации материнской планеты Юпитер.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    SateliteWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Satelite").GetComponent<SateliteWords>();
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
                if (cnt == 12)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 20)
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
