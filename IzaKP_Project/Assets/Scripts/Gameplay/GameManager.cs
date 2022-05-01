using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject selectedskin;
    public GameObject Player;

    private Sprite playersprite;

    bool gameHasEnded = false;

    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.MusicTypes.Gameplay, true);
    }

    //Brackeys Game Over
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
        }


    }

    public void PlayAgain()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
