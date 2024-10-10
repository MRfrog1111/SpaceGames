using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordAstranaut: MonoBehaviour
{
    string text1 = "Вы угадали 12 слов, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Первой женщиной‑космонавтом была Валентина Терешкова.\r\nВ 1962 году, во время поисков первой женщины‑космонавта, Терешкова была выбрана из более чем 400 кандидаток в команду «Востока‑6» — миссии, которая состоялась 16 июня 1963‑го. В тот день Терешкова взлетела с космодрома Байконур в Казахстане. Ее полет продолжался более 70 часов, в течение которых она совершила 48 оборотов вокруг Земли на высоте около 200 километров.\r\n* Космонавты видят 16 восходов солнца в день.\r\nИз‑за того что Международная космическая станция совершает полный оборот вокруг Земли всего за 90 минут, члены экипажа видят рассвет и закат каждые 45 минут. Это может затруднить нормальный ночной сон, особенно когда солнце часто появляется в поле зрения. Поэтому многие космонавты используют маски для сна, чтобы блокировать как можно больше света и стараться поддерживать режим.";
    string text2 = "Вы угадали 30 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Самое долгое время, которое космонавт провел в космосе, — 437 дней.\r\nРекордсменом стал Валерий Поляков, находившийся вне Земли с января 1994 по март 1995 года. Он облетел Землю 7000 раз и провел дни, занимаясь экспериментами и научными исследованиями.\r\n* В космосе люди стареют медленнее, чем на Земле.\r\nУченые заметили, что время замедляется рядом с огромными объектами, потому что их гравитационная сила искривляет его. Это означает, что оно затягивается по мере приближения к Земле, и именно поэтому те, кто находится на Международной космической станции, стареют медленнее, чем мы на Земле. Однако разница невелика — всего доля секунды.";
    string text3 = "Вы угадали 47 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Самому старому космонавту было 77 лет.\r\n29 октября 1998 года Джон Гленн стал старейшим человеком, совершившим полет в космос. Во время девятидневной миссии он изучал влияние космического полета на пожилых людей. При этом это событие стало особенным не только из‑за возраста. Еще оно произошло через 36 лет после исторического полета Гленна в 1962 году, когда он стал первым американцем на орбите.\r\n* Рост космонавтов в космосе увеличивается.\r\nБлагодаря гравитации на Земле, диски в нашем позвоночнике сжимаются вместе. Но в космосе, где она близка к нулю, они декомпрессируются. Это приводит к тому, что летчики временно становятся выше. Когда же они возвращаются на Землю, их рост спустя несколько месяцев приходит к прежним значениям.\r\n";

    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    AstranautWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Astranaut").GetComponent<AstranautWords>();
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
                if (cnt == 30)
                {
                    star2.GetComponent<MeshRenderer>().material = yellow;
                    AboutIlluminator.ShowMassage(text2);

                }
                if (cnt == 47)
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
