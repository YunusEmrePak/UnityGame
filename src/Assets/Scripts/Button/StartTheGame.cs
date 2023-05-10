using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    
    public void StartGame() {
        PlayerMovementController.instance.isStarted = true;
        PlayerMovementController.instance.StartScreen.SetActive(false);
        PlayerMovementController.instance.SettingsScreen.SetActive(false);
    }
}
