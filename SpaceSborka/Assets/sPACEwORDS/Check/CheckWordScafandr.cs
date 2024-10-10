using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordScafandr : MonoBehaviour
{
    string text1 = "Вы угадали 6 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Скафандр (от греч. σκάφος — «лодка» и ἀνήρ — «человек») — это космический костюм-снаряжение для сохранения жизни человека и защиты от вредного влияния внешней среды (жидкостей, газов, излучений). Скафандры защищают космонавтов в открытом космосе от экстремально низкой температуры и позволяют им свободно передвигаться.\r\n* Первые космические скафандры изготавливались по индивидуальным меркам. Сейчас чаще всего выпускают универсальные скафандры, которые можно легко подогнать под разный рост. Единственный элемент скафандра, который остается индивидуальным для каждого члена экипажа — это перчатки.\r\n";
    string text2 = "Вы угадали 14 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Первый скафандр для космических прогулок был разработан в 1934 году российским ученым Юрием Лозиным-Лозинским.\r\n* В настоящее время на борту МКС используются скафандры «Орлан» и его модификации. С 1977 года в этих костюмах совершено более 130 парных выходов в открытый космос.\r\n* \"Орлан\" обеспечивает астронавтам необходимую защиту от воздействия вакуума, радиации и космических микрочастиц, а также поддерживает системы жизнеобеспечения.Он имеет встроенную систему охлаждения, предотвращающую перегрев астронавтов во время прогулок в открытом космосе.\r\n* Вес скафандра \"Орлан\" составляет около 110 кг, но в условиях невесомомсти это практически не ощущается.\r\n";
    string text3 = "Вы угадали 22 словf, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Скафандры космонавтов имеют несколько слоев защиты, включая герметичный внутренний слой, изоляционный слой и внешний защитный слой.\r\n* Шлем скафандра имеет специальное покрытие, которое защищает от солнечной радиации и бликов.\r\n* Скафандры имеют встроенную систему жизнеобеспечения, которая обеспечивает космонавтов кислородом, регулирует температуру и удаляет углекислый газ.\r\n* Скафандры используются не только в космосе, но и в других опасных средах, таких как подводные глубины и химические аварии.\r\n* Первый скафандр, использованный на Луне, был изготовлен из 21 слоя различных материалов.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    ScafandrWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Scafandr").GetComponent<ScafandrWords>();
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
