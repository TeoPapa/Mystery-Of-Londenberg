using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* The class used for the items that are story connected and
 * are getting added to the inventory */
public class Pickup : InteractableItem
{

    private Inventory inventory; //The variable that holds the inventory
    public GameObject itemButton; //The button that is connected to this item

    // Start is called before the first frame update
   private void Start() 
    {
        //Insert to the inventory the Inventory component that is found on the Player
        if (Variables.CharacterType == 1)
        {
            inventory = GameObject.FindGameObjectWithTag("PlayerM").GetComponent<Inventory>();
        }
        else
        {
            inventory = GameObject.FindGameObjectWithTag("PlayerF").GetComponent<Inventory>();
        }
        
    }

    /* When enter is in the item range and interacts with it, pick it up
     * and add it to the inventory */
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("PlayerM") || other.CompareTag("PlayerF"))
        {
            if(interactionNumber == Variables.StoryIndex)
            {
                if(Input.GetKeyDown("e"))
                {
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isFull[i] == false) //Item can be added to the inventory
                        {
                            Instantiate(itemButton, inventory.slots[i].transform, false);
                            inventory.isFull[i] = true;
                            Variables.StoryIndex += 1;
                            Destroy(gameObject);
                            break;
                        }
                    }
                }
            }
            
        }
    }
}
