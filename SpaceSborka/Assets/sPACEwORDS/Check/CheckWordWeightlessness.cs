using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordWeightlessness : MonoBehaviour
{
    string text1 = "Вы угадали 7 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Невесомость – это полное или почти полное отсутствие ощущения веса, т. е. нулевой кажущийся вес. \r\n* Если в состоянии невесомости вылить любую жидкость, она примет шарообразную форму.\r\n* Спички и свечи в невесомости быстро гаснут, так как воздух не перемешивается, и кислород вокруг огня быстро выгорает.\r\n* Космонавтам на борту орбитальной станции приходится обходиться обтиранием тела специальными салфетками, так как душ принять в состоянии невесомости невозможно.\r\n";
    string text2 = "Вы угадали 17 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Специально для невесомости был разработан специальный шампунь, не требующий смывания, и съедобная зубная паста. А волосы на борту МКС приходится стричь с помощью особых ножниц, оснащённых контейнером и пылесосом, чтобы волосы не разлетались.\r\n* Состояние невесомости на долю секунды можно испытать и на Земле. Для этого нужно попрыгать на батуте, и тот краткий миг, когда вы зависаете в верхней точке прыжка, и есть невесомость.\r\n* Космонавты на орбите прибавляют в росте пару сантиметров, так как гравитация не воздействует на позвоночник, и он распрямляется.\r\n* Невесомость воздействует на пауков довольно необычным образом — они начинают плести паутину в форме шара.\r\n";
    string text3 = "Вы угадали 28 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Вокруг неподвижно спящих на борту МКС космонавтов скапливается углекислый газ, и им для дыхания не хватает воздуха. Поэтому перед сном они включают вентиляторы, которые перемешивают воздух.\r\n* Из-за отсутствия физических нагрузок мышцы в состоянии у космонавтов атрофируются. Чтобы минимизировать этот эффект, они используют специальные тренажёры. Но их кости всё равно теряют кальций и становятся хрупкими.\r\n* Принимать пищу в состоянии невесомости не так-то просто, так как она из-за отсутствия силы тяжести не проваливается по пищеводу в желудок сама по себе.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    WeightlessnessWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Weightlessness").GetComponent<WeightlessnessWords>();
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
                if (cnt == 7)
                {
                    star1.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text1);

                }
                if (cnt == 17)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 28)
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
