using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorController : MonoBehaviour
{
    public static PlayerColorController instance;

    public Renderer mainCube;
    public Transform Cubes;

    public int selectedItemId;

    public Material black;
    public Material darkBlue;
    public Material green;
    public Material lighBlue;
    public Material orange;
    public Material pink;
    public Material purple;
    public Material red;
    public Material yellow;
    
    void Awake() {
        instance = this;
    }

    void Start()
    {
        selectedItemId = PlayerPrefs.GetInt("SelectedItemId", -1);
        ChangeTheColor(selectedItemId);
    }

    public void ChangeTheColor(int id) {
        PlayerPrefs.SetInt("SelectedItemId", id);
        switch (id) {
            case 0:
                mainCube.material = black;
                ChangeChildrenMaterial(gameObject, black);
                break;
            case 1:
                mainCube.material = darkBlue;
                ChangeChildrenMaterial(gameObject, darkBlue);
                break;
            case 2:
                mainCube.material = green;
                ChangeChildrenMaterial(gameObject, green);
                break;
            case 3:
                mainCube.material = lighBlue;
                ChangeChildrenMaterial(gameObject, lighBlue);
                break;
            case 4:
                mainCube.material = orange;
                ChangeChildrenMaterial(gameObject, orange);
                break;
            case 5:
                mainCube.material = pink;
                ChangeChildrenMaterial(gameObject, pink);
                break;
            case 6:
                mainCube.material = purple;
                ChangeChildrenMaterial(gameObject, purple);
                break;
            case 7:
                mainCube.material = red;
                ChangeChildrenMaterial(gameObject, red);
                break;
            case 8:
                mainCube.material = yellow;
                ChangeChildrenMaterial(gameObject, yellow);
                break;
        }
    }

    public void ChangeChildrenMaterial(GameObject parent, Material newMaterial)
    {
        int childCount = Cubes.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = Cubes.GetChild(i);
            GameObject childGameObject = childTransform.gameObject;

            Renderer childRenderer = childGameObject.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                childRenderer.material = newMaterial;
            }
        }
    }
}
