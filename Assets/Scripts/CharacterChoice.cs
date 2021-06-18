using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* The class that handles the character picking in the
 * ChooseCharacter scene. */
public class CharacterChoice : MonoBehaviour
{
    public GameObject Load; //The canvas that has the Loading animation

    private void Start() {
        Load.SetActive(false); //Be sure that the Loading canvas is off
    }

    /* If the player chooses boy, set the the type to 1 (meaning boy)
     * and load the SampleScene (the Game Scene) */
    public void ChooseCharacterBoy()
    {       
        Variables.CharacterType = 1;

        Load.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }

    /* If the player chooses boy, set the the type to 1 (meaning boy)
     * and load the SampleScene (the Game Scene) */
    public void ChooseCharacterGirl()
    {
        Variables.CharacterType = 2;

        Load.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }
}
