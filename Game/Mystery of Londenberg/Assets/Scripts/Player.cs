using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool CharacterType; //If the character is boy it's true and if character is girl it's false.
    public bool PlayingGame; //If the game is being played it's true, otherwise it's false.
    public bool OpenedInventory; //If the inventory is opened the value is true. When it's closed the value changes to false.
    public float PlayerMovementSpeed = 5f; //The speed that the player moves arround.
    public Rigidbody2D PlRB; //The body that player has, that allows us to use physics on him.
    public Vector2 Movement; //The movement input that changes the position of the player.
    //public bool Story StoryLine; //The item that holds the whole storyline
    public KeyCode InteractKey; //The key used for interactions.
    public Animator PlayerAnimator; //The animations used for the player's movements.


    // Start is called before the first frame update
    /*void Start()
    {
        
    } */

    // Update is called once per frame
    void Update()
    {
        //Player's Movement
        Movement.x = Input.GetAxisRaw("Horizontal"); //A, D, < or >
        Movement.y = Input.GetAxisRaw("Vertical"); //W, S, ^, !^

        //TODO Here will be the animator's sets
        //Animator's Sets
    }

    private void FixedUpdate()
    {
        //Player's Movement Change
        PlRB.MovePosition(PlRB.position + Movement * PlayerMovementSpeed * Time.fixedDeltaTime);
    }
}
