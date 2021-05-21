using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : InteractableItem
{

    //Item class

    private Inventory inventory;
    public GameObject itemButton;
    public Player player;
    public DialogueType dia;



    // Start is called before the first frame update
   private void Start()
    {
        if (PlayerPrefs.GetInt("CharChoice") == 1)
        {
            player = GameObject.FindGameObjectWithTag("PlayerM").GetComponent<Player>();
            inventory = GameObject.FindGameObjectWithTag("PlayerM").GetComponent<Inventory>();
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("PlayerF").GetComponent<Player>();
            inventory = GameObject.FindGameObjectWithTag("PlayerF").GetComponent<Inventory>();
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("PlayerM") || other.CompareTag("PlayerF"))
        {
            if(interactionNumber == player.CurrStoryIndex)
            {
                if(Input.GetKeyDown("e"))
                {
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isFull[i] == false) //item can be added to the inventory
                        {
                            Instantiate(itemButton, inventory.slots[i].transform, false);
                            inventory.isFull[i] = true;
                            FindObjectOfType<DialogueManager>().StartDialogue(dia);
                            player.SetCurrStoryIndex(player.CurrStoryIndex + 1);
                            Destroy(gameObject);
                            break;
                        }
                    }
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
