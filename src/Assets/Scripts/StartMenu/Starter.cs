using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    public AudioSource Music;

    public int level;

    void Start()
    {
        level = PlayerPrefs.GetInt("LevelCount", 1);
        StartCoroutine(Countdown());
    }


    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Music.Play();
        yield return new WaitForSeconds(3);
        if (level % 2 == 0) {
            SceneManager.LoadScene("Main2");
        }
        else {
            SceneManager.LoadScene("Main1");
        }
    }
}
