using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordMoonRover : MonoBehaviour
{
    string text1 = "Вы угадали 2 слова, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\nЛуноход — это космический исследовательский аппарат, предназначенный для перемещения по поверхности Луны.\r\n\r\nУстройство лунохода:\r\n* Луноход оснащен мощной ходовой частью, состоящей из колес и подвески, позволяющей преодолевать неровности и разнообразные поверхности Луны.\r\n* Луноходы могут быть снабжены солнечными панелями или ядерным источником энергии для обеспечения работы на Луне в условиях отсутствия атмосферы.\r\n* Луноходы обычно оснащены различными научными инструментами, такими как камеры, сенсоры грунта и многими другими.\r\n* Луноход оборудован системами передачи данных, позволяющими отправлять собранные информацию на землю и получать команды от операторов.\r\n";
    string text2 = "Вы угадали 5 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Первый луноход, “Луноход 1”, был запущен Советским Союзом 10 марта 1970 года.\r\n* “Луноход 2” , также созданный Советским Союзом, установил мировой рекорд дистанции на Луне, пройдя более 37 километров.\r\n* Аппарат “Луноход 2” работал на Лунной поверхности 4 месяца, что является рекордом в длительности миссии.\r\n* Луноходы оснащены научными инструментами, такими как спектрометры, радиоизотопные нагреватели, камеры, геологическое оборудование, датчики гравитации и многие другие\r\n";
    string text3 = "Вы угадали 8 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Последний луноход, который был отправлен на Луну, это китайский луноход Yutu-2, он был отправлен в 2019 году на обратную сторону Луны. Yutu-2 проводит исследования, собирает образцы грунта и фотографии в местах, недоступных для других миссий.\r\n* Луноходы устанавливают множество рекордов: от скорости и дальности передвижения до сбора образцов грунта и изучения химического состава Луны.\r\n* Использование луноходов помогло расширить наши знания о Луне и подготовить почву для будущих миссий на спутник Земли и даже на другие планеты.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    MoonRoverWords aw;
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
        aw = GameObject.FindGameObjectWithTag("MoonRover").GetComponent<MoonRoverWords>();
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
