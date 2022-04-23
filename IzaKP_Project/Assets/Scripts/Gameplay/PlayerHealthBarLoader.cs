using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarLoader : MonoBehaviour
{
    public Image myImage;
    public Sprite[] CharacterSkins;
    public bool isAiControlled;

    private void Awake()
    {
        if (!isAiControlled)
        {
            int currentSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
            SetSkin(currentSkin);
            Debug.Log("PLAYER IS " + currentSkin);
        }
    }


    public void SetSkin(int currentSkin)
    {
        if (CharacterSkins.Length > currentSkin)
        {
            myImage.sprite = CharacterSkins[currentSkin];
        }
    }
}
