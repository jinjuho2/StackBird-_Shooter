using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;



    void Awake()
    {
        
    }


    void Update()
    {
        scoreText.text = GameManager.Instance.currentScore.ToString();
    }
}
