using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    { get { return instance; } }

    public int level = 1;
    public int currentScore = 0;
    public int highScore = 0;
    public GameOverUI gameOverUI;
    IntroUI introUI;
     void Awake()
    {
        introUI = FindObjectOfType<IntroUI>();
        instance = this;
        Time.timeScale = 1f;
        if (introUI.isIntroActive)
        {
            Time.timeScale = 0f;
        }    
        gameOverUI.gameObject.SetActive(false);
    }

   

    public void Update()
    {
        if (currentScore % 50 == 0 && currentScore != 0 )
        {
            level++;
        }
        if (currentScore <= 100 && level >= 3)
            level = 2;


        if (level >= 4)
            level = 3;
    }

  
}
