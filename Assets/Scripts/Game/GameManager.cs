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

    GameOverUI gameOverUI;

    private void Awake()
    {
        //gameOverUI = FindObjectOfType<GameOverUI>();
        instance = this;
        Time.timeScale = 1f;
        //gameOverUI.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (currentScore % 50 == 0 && currentScore != 0)
        {
            level++;
        }

        if (level >= 4)
            level = 3;



    }




}
