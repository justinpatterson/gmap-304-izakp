using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedskin;
    public GameObject Player;

    private Sprite playersprite;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.MusicTypes.Gameplay, true);
    }

}
