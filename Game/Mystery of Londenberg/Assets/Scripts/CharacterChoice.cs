using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterChoice : MonoBehaviour
{
    
    public void ChooseCharacterBoy()
    {
        //save they player's choice for boy and change scene
        PlayerPrefs.SetInt("CharChoice", 1);
        SceneManager.LoadScene("SampleScene");
    }

    public void ChooseCharacterGirl()
    {
        //save they player's choice for girl and change scene
        PlayerPrefs.SetInt("CharChoice", 2);
        SceneManager.LoadScene("SampleScene");
    }
}
