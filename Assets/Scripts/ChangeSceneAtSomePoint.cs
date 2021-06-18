using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A class that teleports the player only if he has passed threw a certain milestone of the story */
public class ChangeSceneAtSomePoint : MonoBehaviour
{
    public int interactionNumber; //When will the player be able to get teleported
    public Vector2 WhereToGo; //Where he will get teleported
    public Animator anim; //The animator that fades the screen

    public DialogueType Info; //The info that will pop up if the player can't get teleported


    /* If the player can get teleported, teleport him, else pop up the dialogue */
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerM") || collision.CompareTag("PlayerF")) {
            if (interactionNumber <= Variables.StoryIndex) {
                StartCoroutine(ChangeIt());
            } else {
                FindObjectOfType<DialogueManager>().StartDialogue(Info);
            }
        }
    }

    /* The coroutine that makes the fade usable */
    IEnumerator ChangeIt() {
        anim.SetBool("Transition", true);

        yield return new WaitForSeconds(1);

        FindObjectOfType<Player>().Teleport(WhereToGo);

        yield return new WaitForSeconds(1);

        anim.SetBool("Transition", false);
    }
}
