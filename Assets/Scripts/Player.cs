using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Mystery Of Londenberg
 *  Version: 1.0
 * 
 * Unity does not give free use of the main class, so every general comment will be noted here.
 * 
 * ----------------
 *  Program Changes
 * ----------------
 * 
 * Removed Classes:
 *  - InteractableObject (Turned into InteractableItem and that class deleted. More details on Changes)
 *  
 *  - PlayerPosition (Deleted compeletely. The game was added in a single scene, so teleporting in different scene
 *                    is unusable.Even if we had to teleport to another scene, the static class Variables can handle the same problem)
 *  
 * 
 * 
 * Changed Classes:
 *  - Player (Added more functionality. The inventory, map, hint etc open threw Player's Update method. Added the Teleport method
 *            that teleports the player to the Vector2 parameter)
 *            
 *  - InteractableItem (This class changed to the InteractableObject class. Removed the CanBeInteracted method. Added the Update
 *                      method, that changes the hint.)
 *                      
 *  - NPC (Removed the Start method and the StartTheDialogue method. Added the OnTriggerStay2D method, that handles the interaction)
 *  
 *  - Item (Class changed to PickUp. Removed the PickUp and ShowDescription methods. Added the OnTriggerStay2D method and the Start method)
 *  
 *  - DialogueType (Class now has another class named dialSen, which holds a name and a sentence)
 * 
 *  - ChangeScene (Has only OnTriggerEnter2D. Now instead of loading another scene, the class teleports the player to a certain location
 *                in the map)
 * 
 *  - Story (It's name changed to StoryHandler and now has a plethora of items in it that are being shown or hidden)
 * 
 *  
 *  
 * Added Classes:
 *  - NonObtainableItem (A class that is being used for story items that are not getting added to the inventory)
 *  
 *  - KeepTheSongPlaying (A class that makes the game song playing in-between scenes)
 *  
 *  - ItemDescription (A class that keeps the Description of the items)
 *  
 *  - GeneralItem (A class to pop up dialogues for items or NPC's that have nothing to do with the story)
 *  
 *  - GoToMainMenu (A class that needs a collider, in order to let the player go to MainMenu after the game ended)
 *  
 *  - DialogueTrigger (A class to trigger a dialogue without the need to interact with an object)
 *  
 *  - BlackScreenManager (A class that pops up a black box that surrounds almost the full screen. That black box shows
 *                        some sentences. After every sentence has ended, it teleports the player to a fixed location and pops down
 *                        the black box)
 *  
 *  - ChangeSceneAtSomePoint (If the story index is equal or higher from the int it keeps, it lets player teleport to the propriate location.
 *                            Otherwise, it pops up a dialogue.)
 *  
 *  - ChangeSceneWButton (Changes scenes between MainMenu, Tutorial and ChooseCharacter, while initializing player's position and
 *                        story index)
 * 
 *  - CharacterChoice (Has two methods that initialises the choice of the user (if he chooses boy or girl) and then loads the game
 *  
 *  - ChangeSceneWithBlack (Upon collision, while also having the apropriate interaction number, it pops up and shows on it the black
 *                          screen)
 *                          
 *  - xButton (A class that holds a canvas and is able to close that canvas threw the CloseCanvas function)
 *  
 *  - Variables (A class that holds static values, important to the game (e.g. Character type, StoryIndex)
 *  
 *  - StoryHandler (A class that handles the events of the game)
 *  
 *  - Settings (A class that has methods for use, such as openning the menu, exiting the game and muting the music)
 * ----------------
 */


/* The class that handles the Player's behaviour, including inventory opening,
 * map opening etc.
 */
public class Player : MonoBehaviour
{
    //Note: Deleted the CharacterType and CurrStoryIndex variable, because it's now on the static class Variables

    //Inventory
    public GameObject inventoryCanvas;
    public bool isInventoryOpen = false;
    public GameObject itemsCollected;
    public GameObject itemsCollectedButtons;

    //Map
    public GameObject mapCanvas;
    public bool isMapOpen = false;

    //Hint
    public GameObject hintCanvas;
    public bool isHintOpen = false;

    //Settings
    public GameObject settingsCanvas;
    public bool isSettingsOpen = false;

    public float PlayerMovementSpeed = 5f; //The speed that the player moves arround.
    public Rigidbody2D PlRB; //The body that player has, that allows us to use physics on him.
    public Vector2 Movement; //The movement input that changes the position of the player.
    public KeyCode InteractKey; //The key used for interactions.
    public Animator PlayerAnimator; //The animations used for the player's movements.

    public bool CanMove; //The boolean that allows the user to move the player (for instance, if the player is in a dialogue he can't move)

    public int currIndex; //The current story index

    public bool mute; //If the music is muted
    

    /* Returns the current story index
     */
    public int GetCurrStoryIndex()
    {
        return Variables.StoryIndex;
    }


    void Start()
    {
        Teleport(Variables.PlayerSetPosition);

        CanMove = false;

        if(Variables.CharacterType == 2 && this.gameObject.tag == "PlayerM")
        {
            //If I'm the boy and player chose girl, I delete myself
            Destroy(this.gameObject);
        }
        if(Variables.CharacterType == 1 && this.gameObject.tag == "PlayerF")
        {
            //If I'm the girl and player chose boy, I delete myself
            Destroy(this.gameObject);
        }

        //Close all canvases
        inventoryCanvas.SetActive(false);
        hintCanvas.SetActive(false);
        mapCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    void Update()
    {
        //Player's Movement
        currIndex = Variables.StoryIndex;

        if (CanMove) {
            Movement.x = Input.GetAxisRaw("Horizontal"); //A, D, < or >
            Movement.y = Input.GetAxisRaw("Vertical"); //W, S, ^, v

            //Animations
            PlayerAnimator.SetFloat("Horizontal", Movement.x);
            PlayerAnimator.SetFloat("Vertical", Movement.y);
            PlayerAnimator.SetFloat("Speed", Movement.sqrMagnitude);

            //Idles
            if (Movement.x == 1 || Movement.x == -1 || Movement.y == 1 || Movement.y == -1) {
                PlayerAnimator.SetFloat("LastMoveX", Movement.x);
                PlayerAnimator.SetFloat("LastMoveY", Movement.y);
            }
        }


        //Open and close the inventory 
        if(!isInventoryOpen && Input.GetKeyDown("p"))
        {
            inventoryCanvas.SetActive(true);
            mapCanvas.SetActive(false);
            hintCanvas.SetActive(false);
            isInventoryOpen = true;
        }
        else if(isInventoryOpen && Input.GetKeyDown("p"))
        {
            inventoryCanvas.SetActive(false);
            isInventoryOpen = false;
        }

        //Settings
        if(Input.GetKeyDown(KeyCode.Escape) ) {
            if (!isSettingsOpen) {
                mapCanvas.SetActive(false);
                inventoryCanvas.SetActive(false);
                hintCanvas.SetActive(false);
            }
            OpenCloseSettings();
        }

        //Open and close map
        if (!isMapOpen && Input.GetKeyDown("m"))
        {
            mapCanvas.SetActive(true);
            inventoryCanvas.SetActive(false);            
            hintCanvas.SetActive(false);
            isMapOpen = true;
        }
        else if (isMapOpen && Input.GetKeyDown("m"))
        {
            mapCanvas.SetActive(false);
            isMapOpen = false;
        }

        //Open and close hint
        if (!isHintOpen && Input.GetKeyDown("i"))
        {
            hintCanvas.SetActive(true);
            inventoryCanvas.SetActive(false);
            mapCanvas.SetActive(false);           
            isHintOpen = true;
        }
        else if (isHintOpen && Input.GetKeyDown("i"))
        {
            hintCanvas.SetActive(false);
            isHintOpen = false;
        }

        //Change the player's speed
        if(Input.GetKeyDown(KeyCode.LeftControl))
            FindObjectOfType<Settings>().Faster();
    }

    private void FixedUpdate()
    {
        //Player's Movement Change
        if (CanMove) {
            PlRB.MovePosition(PlRB.position + Movement * PlayerMovementSpeed * Time.fixedDeltaTime);
        }
    }

    /* Teleports the player to the x position
     */
    public void Teleport(Vector2 x) {
        this.transform.position = x;
    }

    /* When this is called, it changes the value of isSettingsOpen and sets the settingsCanvas to that value
     */
    public void OpenCloseSettings() {
        isSettingsOpen = !isSettingsOpen;
        settingsCanvas.SetActive(isSettingsOpen);
    }
}
