using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void GoToShop() {
        PlayerMovementController.instance.ShopScreen.SetActive(true);
    }

    public void CloseShop() {
        PlayerMovementController.instance.ShopScreen.SetActive(false);
    }
}
