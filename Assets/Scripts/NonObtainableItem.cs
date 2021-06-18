using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* A class for the items that are part of the story,
 * but are not getting added to the inventory */
public class NonObtainableItem : InteractableItem
{
    public GameObject note; //The canvas which the item will show up
    public Text sentence; //Where will the description of the item show

    [TextArea(5, 10)]
    public string ItemContent; //The description of the item

    // Start is called before the first frame update
    private void Start() {
        note.SetActive(false); //Make sure that the note is closed
    }

    /* If the player collides with the item and he \
     * interacts, then show the item */
    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown("e")) {
            if (other.CompareTag("PlayerM") || other.CompareTag("PlayerF")) {
                if (interactionNumber == Variables.StoryIndex) {
                    Variables.StoryIndex += 1;
                    showItem();
                }
            }

        }
    }

    /* Set the note canvas on and show the contents of the item */
    private void showItem() {
        note.SetActive(true);
        sentence.text = ItemContent;
    }
}
