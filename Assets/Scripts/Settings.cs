using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* A general class for handling the settings events, such as
 * opening the MainMenu, Muting the music and closing the game
 */
public class Settings : MonoBehaviour
{
    private bool isMute; //The boolean that knows if the music is playing
    public GameObject panel; //The canvas with the Yes or No options
    public Animator Transition; //An animator that can be drawn from other classes
    private bool isOpen; //The boolean that knows if the Yes or No canvas is on
    private bool slowOrFast; //Is the player fast or slow
    private int WhatToDo; //The boolean that knows if player clicked on Exit Game or Main Menu. True means player wants to go to the MainMenu, whilst false means the player wants to quit.

    void Start()
    {
        //When the game starts don't mute the sound and close the canvas
        isMute = false;
        panel.SetActive(false);
    }

    /* Mute is the method that when a button activates,
     * mutes the sound, if the sound is umuted or
     * unmutes the sound if it's muted
     */
    public void Mute()
    {
        isMute = !isMute;
        FindObjectOfType<AudioSource>().mute = isMute;
    }


    /* MainMenu is the method that a button can activate.
     * When it does, it promts you with the Yes or No canvas
     * (Sets WhatToDo as 1)
     */
    public void MainMenu()
    {
        WhatToDo = 1;
        panel.SetActive(true);
    }

    /* Similarly to the MainMenu function, when a player activates the button
     * with ExitGame, promts the player if he wants to exit, whilst sets the
     * WhatToDo as 2
     */
    public void ExitGame()
    {
        WhatToDo = 2;
        panel.SetActive(true);
    }


    /* Sets WhatToDo as 3 and prompts the player to press yes or no. If the yes is pressed,
     * it loads the Credits scene */
     public void CreditsScene() {
        WhatToDo = 3;
        panel.SetActive(true);
    }

    /* If player presses No on the promted canvas, just close the canvas
     */
    public void No()
    {
        panel.SetActive(false);
    }

    /*If player presses Yes, then if he had previously pressed
     * Main Menu, go to the main menu (MainOrExit == true), else
     * Exit the game, (MainOrExit == false)
     */
    public void Yes()
    {
        panel.SetActive(false);
        DoAction(WhatToDo);
    }


    /*If the player has picked yes on the promted canvas, then do the x action.
     * 1 - Go to the MainMenu and destroy the previous playing music (another will start)
     * 2 - Exit the game
     * 3 - Show the Credits Scene (while adding more volume to the sound) */
    public void DoAction(int x) {
        if (WhatToDo == 1) {
            Destroy(FindObjectOfType<AudioSource>());
            SceneManager.LoadScene("MainMenu");
        } else if (WhatToDo == 2)
            Application.Quit();
        else {
            FindObjectOfType<AudioSource>().volume = 0.20f;
            OpenCredits();
        }
    }

    /* Opens the Credits scene */
    public void OpenCredits() {
        SceneManager.LoadScene("Credits");
    }

    /* Makes the player faster/slower */
    public void Faster() {
        slowOrFast = !slowOrFast;

        if (slowOrFast)
            FindObjectOfType<Player>().PlayerMovementSpeed = 15f;
        else
            FindObjectOfType<Player>().PlayerMovementSpeed = 5f;
    }

    /* Upon clicking the close button, it will close the Settings
     * Canvas */
    public void Close() {
        FindObjectOfType<Player>().OpenCloseSettings();
    }
}
