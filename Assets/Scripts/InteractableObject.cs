using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableObject : MonoBehaviour
{
    public bool IsInteractable; //The boolean that knows if the current object can be interacted.
    public InteractableObject nextItem; //The Next Item that will be available for interaction. 


    /*
     * This function checks if this Object is Interactable and if it is makes the Next Object
     * true. Then returns the IsInteractable value.
     */
    public bool CanBeInteracted()
    {
        if (this.IsInteractable)
        {
            nextItem.IsInteractable = true;
        }

        return IsInteractable;
    }
}
