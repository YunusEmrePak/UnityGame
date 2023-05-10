using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public GameObject Slot;
    public List<Items> items;
    public Image selectedImage;
    public int totalDiamonds;
    public TextMeshProUGUI Diamonds;
    public int selectedItemId;

    public List<GameObject> slots = new List<GameObject>();

    void Awake() {
        instance = this;
        for (int j = 0; j < items.Count; j++) {
            PlayerPrefs.SetInt("Item" + j, 0);
            PlayerPrefs.SetInt("BuyItem" + j, 0);
        }
    }

    void Start()
    {
        totalDiamonds = ScoreManager.instance.totalDiamonds;
        Diamonds.text = "" + totalDiamonds;
        selectedItemId = PlayerColorController.instance.selectedItemId;
        if (selectedItemId >= 0 && selectedItemId < items.Count)
        {
            selectedImage.sprite = items[selectedItemId].Picture;
        }
        CallForShop();
    }

    void Update() {
        Diamonds.text = "" + totalDiamonds;
    }

    void CallForShop()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject addSlot = Instantiate(Slot, transform);
            slots.Add(addSlot);
            InitializeSlot(addSlot, i);
        }
    }

    void InitializeSlot(GameObject slot, int i)
    {
        slot.GetComponent<Image>().sprite = items[i].Picture;

        bool isBought = PlayerPrefs.GetInt("Item" + i, 0) == 1;
        bool isSelected = PlayerPrefs.GetInt("BuyItem" + i, 0) == 1;

        items[i].Price = 100;
        items[i].IsBought = isBought;
        items[i].IsSelected = isSelected;
        string buttonText;

        if (isBought)
        {
            buttonText = isSelected ? "Selected" : "Select";
        }
        else
        {
            buttonText = "Buy (" + 100 + ")";
        }
        
        slot.transform.Find("BuyButton").transform.Find("Text").GetComponent<Text>().text = buttonText;

        int identifier = i;
        slot.transform.Find("BuyButton").GetComponent<Button>().onClick.RemoveAllListeners();
        slot.transform.Find("BuyButton").GetComponent<Button>().onClick.AddListener(() => Buy(identifier, slot));
    }


    public void Buy(int id, GameObject slot)
    {
        if (items[id].IsBought)
        {
            if (!items[id].IsSelected) {
                // Debug.Log("here2");
                items[id].IsSelected = true;
                PlayerPrefs.SetInt("BuyItem" + id, 1);
                selectedImage.sprite = items[id].Picture;
                selectedItemId = id;
                PlayerColorController.instance.ChangeTheColor(id);
                PlayerPrefs.SetInt("SelectedItemId", selectedItemId);

                RefreshShop();
            }
            return;
        }

        if (!items[id].IsBought && totalDiamonds >= items[id].Price)
        {
            PlayerColorController.instance.ChangeTheColor(id);
            selectedImage.sprite = items[id].Picture;
            selectedItemId = id;
            PlayerPrefs.SetInt("SelectedItemId", selectedItemId);
            totalDiamonds -= items[id].Price;
            items[id].IsBought = true;
            items[id].IsSelected = true;

            PlayerPrefs.SetInt("Item" + id, 1);
            PlayerPrefs.SetInt("BuyItem" + id, 1);

            PlayerPrefs.SetInt("TotalDiamonds", totalDiamonds);

            selectedImage.sprite = items[id].Picture;

            // Refresh shop
            RefreshShop();
        }
        else
        {
            Debug.Log("Not enough diamonds");
        }
        PlayerPrefs.SetInt("SelectedMaterialId", id);
    }


    public void RefreshShop()
    {
        for (int i = 0; i < slots.Count; i++)
        { 
            InitializeSlot(slots[i], i);
            items[i].IsSelected = false;
            PlayerPrefs.SetInt("BuyItem" + i, items[i].IsSelected ? 1 : 0);
        }
    }
}

[System.Serializable]
public class Items
{
    public string Name;
    public Sprite Picture;
    public int Price;
    public bool IsBought;
    public bool IsSelected;

    public Items(string name, Sprite picture, int price, bool isBought, bool isSelected)
    {
        Name = name;
        Picture = picture;
        Price = price;
        IsBought = isBought;
        IsSelected = isSelected;
    }
}
