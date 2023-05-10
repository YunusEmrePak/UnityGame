using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void RestartTheGame() {
        PlayerMovementController.instance.StartScreen.SetActive(true);
        PlayerMovementController.instance.FailScreen.SetActive(false);
        Time.timeScale = 1;
        Finish.instance.LoadScene();
    }
}
