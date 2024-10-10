using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CheckWordCosmodrome : MonoBehaviour
{
    string text1 = "Вы угадали 4 слова, уровень пройден на 1 звезду. Так держать!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Космодром — это территория с расположенным на ней комплексом специальных сооружений и технических систем, предназначенная для запусков космических аппаратов.\r\n* Стартовая площадка ракеты строится как можно дальше от крупных населенных пунктов, чтобы снизить риск для прохожих в случае катастрофического отказа ракеты. Во многих случаях стартовая площадка строится недалеко от крупных водоемов, чтобы гарантировать, что никакие компоненты не попадут в населенные районы. Обычно космодром достаточно велик, чтобы в случае взрыва транспортного средства он не подвергал опасности жизни людей или близлежащие стартовые площадки.\r\n";
    string text2 = "Вы угадали 10 слов, уровень пройден на 2 звезды. Поздравляю вас!\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Космодром Байконур в Казахстане, легендарное космическое сообщество, является старейшим и крупнейшим космодромом в мире. Это место проведения многих исторических событий в космической программе, включая запуск первого искусственного спутника и первого человека в космосе.\r\n\r\n* Внуково-Восточный космодром, расположенный на Дальнем Востоке России, является новым и перспективным космодромом, развиваемым для будущих гражданских и военных космических проектов.\r\n";

    string text3 = "Вы угадали 16 слов, уровень пройден на 3 звезды. Завидую вашему словарному запасу:)\r\n\r\n\r\nКстати, а вы знали, что:\r\n* Современные космодромы оборудованы технологичными системами запуска, включая мощные ракеты-носители, системы наблюдения и управления, поддерживающие космические аппараты и астронавтов на всех этапах миссий.\r\n* Космодромы часто становятся местом для мультинациональных проектов и сотрудничества. Например, в Международной космической станции (МКС) работают астронавты из разных стран, а операции контроля и поддержки происходят с космодромов по всему миру.\r\n";
    Button check;
    public Text count;
    public List<string> gList = new List<string>();
    public Text guessed;
    string word;
    CosmodromeWords aw;
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
        aw = GameObject.FindGameObjectWithTag("Cosmodrome").GetComponent<CosmodromeWords>();
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
