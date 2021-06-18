using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The class that changes the scene with poping the black screen of the game */
public class ChangeSceneWithBlack : MonoBehaviour
{
    public int interactionNumber; //The interaction number that the black screen is able to pop up

    public Vector2 PositionToGo; //Where will the player get teleported
    
    public bool WillAdd; //Will the black screen add to the story

    [TextArea(5, 10)]
    public string[] WhatToShow; //What will be shown on the black screen


    /* Upon collision, if the number is apropriate pop up the black screen.
     * Also, if the WillAdd is true, add one to the StoryIndex */
    private void OnTriggerStay2D(Collider2D collision) {
        if (interactionNumber == Variables.StoryIndex) {
            if (collision.CompareTag("PlayerM") || collision.CompareTag("PlayerF")) {
                FindObjectOfType<BlackScreenManager>().StartDialogue(WhatToShow, PositionToGo);
                if (WillAdd)
                    Variables.StoryIndex += 1;
            }
        }
    }
}
