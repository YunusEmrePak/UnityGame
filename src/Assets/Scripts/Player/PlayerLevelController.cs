using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevelController : MonoBehaviour
{
    public static PlayerLevelController instance;
    public int levelCount;

    void Awake() {
        instance = this;
    }

    void Start()
    {   
        levelCount = PlayerPrefs.GetInt("LevelCount", 1);
        // PlayerPrefs.SetInt("LevelCount", 1);
    }

    public void LoadNextLevel()
    {
        levelCount++;
        PlayerPrefs.SetInt("LevelCount", levelCount);
    }

    
}
