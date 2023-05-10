using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField] private Text TapToPlay;
    [SerializeField] private GameObject HandIcon;

    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI levelText;
    public int score;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        txtScore.text = "" + ScoreManager.instance.totalDiamonds;
        levelText.text = "Level " + PlayerLevelController.instance.levelCount;
    }
    
}
