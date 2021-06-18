using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* A class for the items that are not included in the story */
public class GeneralItem : MonoBehaviour
{
    public DialogueType[] dia; /* The dialogue that pops up when the player interacts with those items
                                * (its not just one dialogue, cause some items might keep more dialogues in them) */
    private int index;

    private void Start() {
        index = 0;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("PlayerM") || collision.CompareTag("PlayerF")) {
            if (Input.GetKeyDown("e")) {
                FindObjectOfType<DialogueManager>().StartDialogue(dia[index]);
                if (index + 1 < dia.Length)
                    index += 1;
            }
        }
    }
}
