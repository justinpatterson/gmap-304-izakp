using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterLoader : MonoBehaviour
{
    public Animator myAnimator;
    public RuntimeAnimatorController[] animatorSkins;
    public bool isAiControlled;

    private void Awake()
    {
        int currentSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        if (isAiControlled)
        {
            currentSkin = (currentSkin + 1);// % animatorSkins.Length;
            if (currentSkin >= animatorSkins.Length)
            {
                currentSkin = 0;
            }
        }
        if (animatorSkins.Length > currentSkin) {
            myAnimator.runtimeAnimatorController = animatorSkins[currentSkin];
        }
    }
}
