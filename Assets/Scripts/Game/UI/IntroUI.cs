using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    public GameObject introPanel; // ����â �г�

    public bool isIntroActive = true;


    void Start()
    {
        if (introPanel != null)
        {
            introPanel.SetActive(true); // ������ �� ����â Ȱ��ȭ
        }
    }

    void Update()
    {
        if (isIntroActive && Input.GetKeyDown(KeyCode.Return)) // Enter Ű Ȯ��
        {
            if (introPanel != null)
            {
                introPanel.SetActive(false); // ����â ��Ȱ��ȭ
                isIntroActive = false; // �� �̻� �Է¹��� ����
                Time.timeScale = 1f; // ���� �ð� �簳
            }
        }
    }
}
