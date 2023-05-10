using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutUs : MonoBehaviour
{
    public void OpenAboutUs() {
        PlayerMovementController.instance.AboutUsScreen.SetActive(true);
        PlayerMovementController.instance.StartScreen.SetActive(false);
        PlayerMovementController.instance.SettingsScreen.SetActive(false);
    }

    public void CloseAboutUs() {
        PlayerMovementController.instance.AboutUsScreen.SetActive(false);
        PlayerMovementController.instance.StartScreen.SetActive(true);
        PlayerMovementController.instance.SettingsScreen.SetActive(true);
    } 
}
