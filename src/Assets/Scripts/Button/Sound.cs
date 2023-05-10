using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Image targetImage;
    public Sprite OnSprite;
    public Sprite OffSprite;
    private const string SOUND_PREF_KEY = "SoundState";

    void Start()
    {
        LoadSoundState();
    }

    public void ControlSound() {
        bool isClicked = PlayerPrefs.GetInt(SOUND_PREF_KEY, 0) == 1;

        if (!isClicked) {
            PlayerPrefs.SetInt(SOUND_PREF_KEY, 1);
            targetImage.sprite = OffSprite;
            AudioListener.pause = true;
            AudioListener.volume = 0f;
        }
        else {
            PlayerPrefs.SetInt(SOUND_PREF_KEY, 0);
            targetImage.sprite = OnSprite;
            AudioListener.pause = false;
            AudioListener.volume = 1f;
        }

        PlayerPrefs.Save();
    }

    private void LoadSoundState()
    {
        bool isClicked = PlayerPrefs.GetInt(SOUND_PREF_KEY, 0) == 1;
        targetImage.sprite = isClicked ? OffSprite : OnSprite;
        AudioListener.pause = isClicked;
        AudioListener.volume = isClicked ? 0f : 1f;
    }
}
