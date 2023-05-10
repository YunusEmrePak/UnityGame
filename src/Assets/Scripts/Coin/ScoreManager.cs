using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public static ScoreManager instance;
    public int totalDiamonds;

    public TextMeshProUGUI txtScore;

    void Awake()
    {
        instance = this;
        // PlayerPrefs.SetInt("TotalDiamonds", 0);
    }
    void Start() {
        totalDiamonds = PlayerPrefs.GetInt("TotalDiamonds", 1000);
    }

    public void IncreaseScore()
    {
        score++;
        txtScore.text = "" + score;
    }

    public void AddLastScore() {
        totalDiamonds += score;
        PlayerPrefs.SetInt("TotalDiamonds", totalDiamonds);
    }
   
}
