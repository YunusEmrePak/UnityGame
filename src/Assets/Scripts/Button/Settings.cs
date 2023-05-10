using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public bool isClicked;

    public void ControlSettings() {
        if (!isClicked) {
            isClicked = true;
            PlayerMovementController.instance.SettingsScreen.SetActive(true);
        }
        else {
            isClicked = false;
            PlayerMovementController.instance.SettingsScreen.SetActive(false);
        }
        
        
    }

}
