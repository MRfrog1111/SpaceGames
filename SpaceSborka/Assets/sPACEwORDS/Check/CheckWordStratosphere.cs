using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordStratosphere : MonoBehaviour
{
    string text1 = "Вы угадали 12 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Стратосфера - это 2-й слой атмосферы, расположенный между тропосферой и мезосферой.\r\n* Особенностью стратосферы является повышение температуры с высотой – с -56С до +0,8С.\r\n* На высоте примерно 35 км плотность земной атмосферы уже практически мало чем отличается от вакуума и составляет примерно 1/100 от плотности на уровне моря. Примерно такая же плотность у атмосферы Марса на уровне его поверхности.\r\n";
    string text2 = "Вы угадали 28 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* В стратосфере практически нет облачности, так как там атмосфера уже слишком разреженная, а значит, там мало водяного пара, однако на высоте 22-24 км все же наблюдаются перламутровые облака из кристалликов льда.\r\n* Стратосфера содержит 90% всего озона в атмосфере Земли. Озоновый слой поглощает дальний ультрафиолет, губительный для живых организмов. К сожалению, с 1980-х годов в стратосфере над Антарктидой наблюдается устойчивое явление – озоновая дыра или пониженное содержание озона.\r\n* Другая важная функция озона – он задерживает часть излучения Земли, благодаря чему нижние слои атмосферы сохраняют достаточно тепла.\r\n";
    string text3 = "Вы угадали 45 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Условия в стратосфере близки к условиям на низкой околоземной орбите, благодаря чему стратосферу часто называют near space («почти космос»). Стратосфера используется для испытаний различных элементов оборудования космических аппаратов в условиях, приближенных к их реальным условиям эксплуатации.\r\n* Летальные аппараты стали достигать стратосферы уже в 30-е гг. 20 в. Это были стратостаты, сумевшие подняться на высоту в 16 километров. Советским конструкторам удалось поднять стратостат на три километра выше, что было новым мировым рекордом, зафиксированным в 1933 г.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    StratosphereWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Stratosphere").GetComponent<StratosphereWords>();
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

                if (cnt == 12)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 28)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 45)
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
