using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarLoader : MonoBehaviour
{
    public Image myImage;
    public Sprite[] CharacterSkins;

    private void Awake()
    {
        int currentSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        if (CharacterSkins.Length > currentSkin)
        {
            myImage.sprite = CharacterSkins[currentSkin];
        }
    }
}
