using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int CharacterType = 1; //If the character is boy it's 1 and if character is girl it's 2.
    public int CurrStoryIndex; //the current interaction the player has to make

    public GameObject inventoryCanvas;
    public bool isInventoryOpen = false;

    public bool PlayingGame; //If the game is being played it's true, otherwise it's false.
    public float PlayerMovementSpeed = 5f; //The speed that the player moves arround.
    public Rigidbody2D PlRB; //The body that player has, that allows us to use physics on him.
    public Vector2 Movement; //The movement input that changes the position of the player.
    public KeyCode InteractKey; //The key used for interactions.
    public Animator PlayerAnimator; //The animations used for the player's movements.

    
    public int GetCurrStoryIndex()
    {
        return CurrStoryIndex;
    }

    public void SetCurrStoryIndex(int index)
    {
        CurrStoryIndex = index;
    }


    void Start()
    {
        CurrStoryIndex = 0;

       

        CharacterType = PlayerPrefs.GetInt("CharChoice"); //fetch the player's choice of character
        if(CharacterType == 2 && this.gameObject.tag == "PlayerM")
        {
            //if im a boy and player chose girl, i delete myself
            Destroy(this.gameObject);
        }
        if(CharacterType == 1 && this.gameObject.tag == "PlayerF")
        {
            //if im a girl and player chose boy, i delete myself
            Destroy(this.gameObject);
        }

        inventoryCanvas.SetActive(false);

    }

    void Update()
    {
        //Player's Movement
        Movement.x = Input.GetAxisRaw("Horizontal"); //A, D, < or >
        Movement.y = Input.GetAxisRaw("Vertical"); //W, S, ^, v
                        
        //Animations
        PlayerAnimator.SetFloat("Horizontal", Movement.x);
        PlayerAnimator.SetFloat("Vertical", Movement.y);
        PlayerAnimator.SetFloat("Speed", Movement.sqrMagnitude);
        
        //Idles
        if(Movement.x == 1 || Movement.x == -1 || Movement.y == 1 || Movement.y == -1) {
            PlayerAnimator.SetFloat("LastMoveX", Movement.x);
            PlayerAnimator.SetFloat("LastMoveY", Movement.y);
        }

        if(!isInventoryOpen && Input.GetKeyDown("p"))
        {
            inventoryCanvas.SetActive(true);
            isInventoryOpen = true;
        }

        else if(isInventoryOpen && Input.GetKeyDown("p"))
        {
            inventoryCanvas.SetActive(false);
            isInventoryOpen = false;
        }
    }

    private void FixedUpdate()
    {
        //Player's Movement Change
        PlRB.MovePosition(PlRB.position + Movement * PlayerMovementSpeed * Time.fixedDeltaTime);
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if(other.gameObject.tag == "InteractableItem")
    //    {
    //        //if the other object is an item
    //        if(other.gameObject.GetComponent<InteractableItem>().GetInteractionNumber() == CurrStoryIndex)
    //        {
    //            if (Input.GetKeyDown(InteractKey))
    //            {
    //                //collect it and advance the currstoryindex
    //                Destroy(other.gameObject);
    //                CurrStoryIndex++;
    //            }
                   
    //        }
    //    }
    //    else if(other.gameObject.tag == "InteractableNPC")
    //    {
    //        //if the other object is an npc
    //        if(other.gameObject.GetComponent<InteractableItem>().GetInteractionNumber() == CurrStoryIndex)
    //        {
    //            if (Input.GetKeyDown(InteractKey))
    //            {
    //                //PAIKSE TON DIALOGO TOU NPC
    //                CurrStoryIndex++;
    //            }
    //        }
    //    }
    //}

}
