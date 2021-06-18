using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*The class that is used for every NPC (Non Playable Character)
 * that plays a part in the story of the game */
public class NPC : MonoBehaviour
{
    public DialogueType[] NPCDial; /* The dialogues that an NPC keeps (at least 2, because
                                    * if the player is not able to speak with the NPC at the moment,
                                    * he'll be shown a trivial dialogue) */
    public int[] interactionNumbers; //The interaction numbers that need to be active to show the next NPCDial
    public int index = 0; //The index of the NPCDial
    public string[] hintString; //The String that will be shown on the hint canvas
    public Text hintText; //The text box for the hint cavas

    /* For each frame of the game, if the StoryIndex, becomes equal to
     * the interaction number, set the hintString to the hint */
    void Update()
    {
        for (int i = 0; i < hintString.Length; i++)
        {
            if (Variables.StoryIndex == interactionNumbers[i])
            {
                hintText.text = hintString[i];
            }
        }
    }

    /* Upon collision and interaction, if the player is currently on the interaction place,
     * then show the next story dialogue, else show the previous dialogue */
    void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("PlayerM") || other.CompareTag("PlayerF")) {

                if (Input.GetKeyDown("e")) {
                if (!(index >= interactionNumbers.Length)) {
                    if (interactionNumbers[index] == Variables.StoryIndex) {
                        index += 1;
                        Variables.WillAdd = true;
                        FindObjectOfType<DialogueManager>().StartDialogue(NPCDial[index]);
                        return;
                    }
                }
                    FindObjectOfType<DialogueManager>().StartDialogue(NPCDial[index]);
            }
        }
    }
}