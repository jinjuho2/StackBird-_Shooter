using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public Button restart;
    public Button Exit;
    public TextMeshProUGUI bestScore;

    private void Awake()
    {
        
    }

    private void Update()
    {
        bestScore.text = GameManager.Instance.currentScore.ToString();
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void OnClickExit()
    {
        SceneManager.LoadScene("Go");
    }

    
}
