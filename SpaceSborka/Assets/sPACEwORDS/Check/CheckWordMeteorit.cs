using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordMeteorit : MonoBehaviour
{
    string text1 = "Вы угадали 4 слова, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\nМетеори́т (от др. — греч. «метеорос» — парящий в воздухе) — тело, имеющее космическое положение, не сгоревшее в слоях атмосферы и долетевшее до Земли . \r\n\r\nЗа сутки на Землю падает около 5-6 тонн метеоритного вещества. Это составляет около 2 тысяч тонн в год. Казалось бы – довольно много. Но большинство метеоритов сгорают в атмосфере, так и не долетев до земли. Из остальных значительная часть падает в океан или малонаселенные области – просто потому, что они занимают большую часть нашей планеты. И лишь в редких случаях падение метеорита происходит в населенной местности, на глазах у людей. \r\n";
    string text2 = "Вы угадали 10 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\nКосмические тела двигаются с огромными скоростями. При входе в атмосферу скорость метеорита может достигать от 11 до 72 км/с. От трения о воздух он загорается и начинает светиться. Как правило, большинство метеоритов сгорают, не достигая поверхности. Крупный метеорит постепенно замедляется и остывает. То, что будет происходить дальше, зависит от многих факторов – масса, начальная скорость, угол входа в атмосферу. Если метеорит успевает затормозить, его траектория может смениться на почти отвесную и он просто упадет на поверхность. Бывает, что внутренняя структура метеорита неоднородная, неустойчивая. И тогда он взрывается в воздухе, а его обломки падают на землю. Такое явление называется метеоритным дождем. Но если скорость метеорита все еще велика (около 2-4 км/с), а сам он достаточно массивен – при столкновении с земной поверхностью происходит мощный взрыв.";
    string text3 = "Вы угадали 16 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\nНа месте падения крупного метеорита образуется метеоритный кратер – астроблема. На Земле такие кратеры не всегда видны, поскольку выветривание и прочие геологические процессы разрушают их. Но на других планетах можно увидеть следы колоссальных метеоритных бомбардировок.\r\nМетеоритные кратеры есть и на территории России. Самый большой из них находится в Восточной Сибири. Это кратер Попигай, его диаметр 100 км, и он четвертый по величине в мире. Попигай образовался 35,7 млн лет назад в результате столкновения с Землей крупного астероида. Есть сведения, что в его недрах скрываются залежи алмазов, но точная информация об этом была засекречена еще в советское время. Самый древний из российских кратеров (и один из древнейших в мире) – это небольшой кратер Суавъярви в Карелии. Его диаметр всего 3 км и сейчас в нем расположено озеро. Но его возраст – 2,4 миллиарда лет – впечатляет.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    MeteoritWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Meteorit").GetComponent<MeteoritWords>();
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
                if (cnt == 4)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 10)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 16)
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
