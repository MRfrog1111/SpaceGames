using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
    bool index = true;
    public GameObject Ship;
    public List<Transform> spawnPoints;
    bool Pointer = false;
    private float _timeLeft = 0f;
    public Transform Target;
    public RectTransform PointerUI;
    public Sprite PointerIcon;
    public Sprite OutOfScreenIcon;
    public float InterfaceScale = 100;
    private Vector3 startPointerSize;
    private Camera mainCamera;
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }


    private void Start()
    {
        startPointerSize = PointerUI.sizeDelta;
        mainCamera = Camera.main;
        spawnPoints = new List<Transform>(spawnPoints);
        _timeLeft = time;
        StartCoroutine(StartTimer());
        PointerUI.gameObject.SetActive(false);
        Target.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Pointer == true)
        {
            Vector3 realPos = mainCamera.WorldToScreenPoint(Target.position);
            Rect rect = new Rect(0, 0, Screen.width, Screen.height);

            Vector3 outPos = realPos;
            float direction = 1;

            PointerUI.GetComponent<Image>().sprite = OutOfScreenIcon;

            if (!IsBehind(Target.position))
            {
                if (rect.Contains(realPos))
                {
                    PointerUI.GetComponent<Image>().sprite = PointerIcon;
                }
            }
            else
            {
                realPos = -realPos;
                outPos = new Vector3(realPos.x, 0, 0);
                if (mainCamera.transform.position.y < Target.position.y)
                {
                    direction = -1;
                    outPos.y = Screen.height;
                }
            }

            float offset = PointerUI.sizeDelta.x / 2;
            outPos.x = Mathf.Clamp(outPos.x, offset, Screen.width - offset);
            outPos.y = Mathf.Clamp(outPos.y, offset, Screen.height - offset);

            Vector3 pos = realPos - outPos;

            RotatePointer(direction * pos);

            PointerUI.sizeDelta = new Vector2(startPointerSize.x / 100 * InterfaceScale, startPointerSize.y / 100 * InterfaceScale);
            PointerUI.anchoredPosition = outPos;
        }
         bool IsBehind(Vector3 point)
        {
            Vector3 forward = mainCamera.transform.TransformDirection(Vector3.forward);
            Vector3 toOther = point - mainCamera.transform.position;
            if (Vector3.Dot(forward, toOther) < 0) return true;
            return false;
        }
         void RotatePointer(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            PointerUI.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    
        if (_timeLeft <= 60 & index == true)
        {
            Pointer = true;
            PointerUI.gameObject.SetActive(true);
            Target.gameObject.SetActive(true);
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(Ship, spawnPoints[spawn].transform.position, Quaternion.identity);
            Debug.Log("Банан");
            index = false;
        }
    }
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
