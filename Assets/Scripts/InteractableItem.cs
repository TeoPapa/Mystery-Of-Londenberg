using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*The super class, that has the similar parts of an NPC and an Item (when they are able to get interacted) */
public class InteractableItem : MonoBehaviour
{  

    public int interactionNumber; //When the player is able to interact with the InteractableItem
    public string hintString; //The string for the hint
    public Text hintText; //The text box of the hint


    /* Returns the interactionNumber of the item */
    public int GetInteractionNumber()
    {
        return interactionNumber;
    }

    void Update()
    {

        //when this Item/NPC is next, change the hint text to show where to find it/them or where to go
        if(Variables.StoryIndex == interactionNumber)
        {
            hintText.text = hintString;
        }
    }
   
}
