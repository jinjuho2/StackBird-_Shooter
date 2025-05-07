using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    public GameObject introPanel; // 설명창 패널

    public bool isIntroActive = true;


    void Start()
    {
        if (introPanel != null)
        {
            introPanel.SetActive(true); // 시작할 때 설명창 활성화
        }
    }

    void Update()
    {
        if (isIntroActive && Input.GetKeyDown(KeyCode.Return)) // Enter 키 확인
        {
            if (introPanel != null)
            {
                introPanel.SetActive(false); // 설명창 비활성화
                isIntroActive = false; // 더 이상 입력받지 않음
                Time.timeScale = 1f; // 게임 시간 재개
            }
        }
    }
}
