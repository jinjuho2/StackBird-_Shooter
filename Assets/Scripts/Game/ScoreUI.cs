using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;



    void Awake()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }


    void Update()
    {
        scoreText.text = GameManager.Instance.currentScore.ToString();
    }
}
