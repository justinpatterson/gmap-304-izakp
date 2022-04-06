using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterLoader : MonoBehaviour
{
    public Animator myAnimator;
    public RuntimeAnimatorController[] animatorSkins;

    private void Awake()
    {
        int currentSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        if (animatorSkins.Length > currentSkin) {
            
        }
    }
}
