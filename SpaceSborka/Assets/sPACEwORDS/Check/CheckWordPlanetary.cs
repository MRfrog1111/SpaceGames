using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordPlanetary : MonoBehaviour
{
    string text1 = "Вы угадали 17 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Планетарий - это здание или помещение, в котором с помощью специального проектора на полусферический экран проецируется реалистичное изображение ночного неба. Это позволяет зрителям наблюдать звезды, планеты и другие небесные объекты.\r\n* Московский планетарий — одно из самых завораживающих мест столицы. Здесь можно совершать путешествия среди звезд и туманностей, изучать Вселенную. Сегодня это самый технически оснащенный научно-популярный астрономический центр в мире.\r\n";
    string text2 = "Вы угадали 43 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Московский планетарий открылся 5 ноября 1929 года. Это было большое событие для России. На тот момент в мире существовало всего 12 планетариев, из них 10 в Германии и по одному в Италии и Австрии. Сегодня звездному дому исполняется 91 год.\r\n* Каждый год в планетарии разрабатывают новые экскурсии и учебные программы для детей и взрослых, появляются новые экспонаты, проходят лекции выдающихся ученых, обновляются технологии. Здесь есть классический и интерактивный музеи, две обсерватории, открытая астрономическая площадка, 4D-кинотеатр и два звездных зала — такого многообразия нет больше ни в одном научно-просветительском центре.\r\n";
    string text3 = "Вы угадали 68 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Парк неба - это комплекс астрономических приборов и инструментов, соединение астрономической обсерватории и музея под открытым небом – достопримечательность Московского планетария. \r\n* Уникальная коллекция: солнечные часы – от гигантских площадных до компактных садово-парковых; ни с чем не сравнимый вид вращающихся серебристых куполов башен-обсерваторий, дуги небесных сфер, индийская крылатая лестница в небо Самрат Янтра, каменное кольцо Стоунхенджа, пирамида Хуфу (Хеопса), глобусы – земной и небесный, полярный зонт, армиллярная сфера, геоскоп, Московский меридиан – вот лишь неполный перечень экспонатов Парка неба – живописного уголка истории познания Земли и неба.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    PlanetaryWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Planetary").GetComponent<PlanetaryWords>();
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
                if (cnt == 17)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 43)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 68)
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
