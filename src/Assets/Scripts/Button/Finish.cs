using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static Finish instance;

    void Awake() {
        instance = this;
    }

    public void LoadScene() {
        if (PlayerLevelController.instance.levelCount % 2 == 0) {
            SceneManager.LoadScene("Main2");
        }
        else {
            SceneManager.LoadScene("Main1");
        }
        // PlayerMovementController.instance.FinishScreen.SetActive(false);
    }
}
