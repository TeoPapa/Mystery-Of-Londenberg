using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A class that driggers a dialogue upon collision */
public class DialogueTrigger : MonoBehaviour
{
    public DialogueType TriggeredDialogue; //The dialogue that pops up
    public int InteractionNumber; //The interaction number upon which the Dialogue will get poped up

    /* Upon collision if the StoryIndex is equal to the interactionNumber then pop up dialogue */
    public void OnTriggerEnter2D(Collider2D collision) {
        if (Variables.StoryIndex == InteractionNumber) {
            if (collision.CompareTag("PlayerM") || collision.CompareTag("PlayerF")) {
                Variables.WillAdd = true;
                FindObjectOfType<DialogueManager>().StartDialogue(TriggeredDialogue);
            }
        }
    }
}
