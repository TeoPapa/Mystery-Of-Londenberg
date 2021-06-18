using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* A class that pops up, when called, the black screen, showing text.
 * After that it teleports the player to a certain location */
public class BlackScreenManager : MonoBehaviour
{
    public Text detText; //The UI property where the text will be put (dialogue)

    public Animator Anim; //The animator where the dialogue pops up and pops down

    private Vector2 WhereToGo; //The position where the player will be teleported after the end of the text

    private Queue<string> sentences; //The sentences of a dialogue

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
    }

    /* Initializes the black box, poping up the canvas, setting the sentences to the queue etc. */
    public void StartDialogue(string[] des, Vector2 toGo) {
        Anim.SetBool("IsOpen", true);
        FindObjectOfType<Player>().CanMove = false;

        WhereToGo = toGo;

        sentences.Clear();

        foreach (string sentence in des) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /* The method that displays the next sentence when the player hits the next button. */
    public void DisplayNextSentence() {
        if (sentences.Count == 0) { //There are no more things to show, so close
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        detText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            detText.text += letter;
            yield return new WaitForSeconds(.03f);
        }
    }



    /* A function that close the UI of the dialogue, meaning the dialogue has ended. */
    public void EndDialogue() {
        FindObjectOfType<Player>().Teleport(WhereToGo);
        FindObjectOfType<Player>().CanMove = true;
        Anim.SetBool("IsOpen", false);
    }
}
