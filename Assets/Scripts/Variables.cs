using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* A general class keeping static variables for various
 * reasons in the game
 */
public class Variables : MonoBehaviour
{
    public static int CharacterType; //It holds wether the user picked boy or girl
    public static Vector2 PlayerSetPosition; //It holds a position and when the player is getting loaded on another scene, he gots teleported there
    public static int StoryIndex = 0; //The variable that handles the story. According to this variable the player is able to pick up items, speak to NPCs etc.

    public static bool WillAdd; //A variable that defines if the StoryIndex will get increased
}
