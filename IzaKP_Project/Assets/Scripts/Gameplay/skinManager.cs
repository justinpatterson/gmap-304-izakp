using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class skinManager : MonoBehaviour
{
    //list that holds all of the skins
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();

    //To keep track of what the skin is currently selected
    private int selectedSkin = 0;

    //Skin for the actual player
    public GameObject playerskin;

    //run when we click the next button
    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        //move to the next skin
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
    }

    //run when we click the back button
    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        //move to the last skin
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
        sr.sprite = skins[selectedSkin];
    }

    //run the play button
    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/Prefabs/selectedSkin.prefab");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
