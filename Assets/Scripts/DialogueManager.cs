using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Manages the dialogue events of the game */
public class DialogueManager : MonoBehaviour
{
    public Text nameText; //The UI property where the name will be put
    public Text diaText; //The UI property where the text will be put (dialogue)

    public Animator Anim; //The animator where the dialogue pops up and pops down

    private Queue<dialSen> sentences; //The sentences of a dialogue

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<dialSen>();
    }

    /* Initializes the dialogue, entering the name, pops up the UI etc. */
    public void StartDialogue(DialogueType Dia) {
        Anim.SetBool("IsOpen", true);
        FindObjectOfType<Player>().CanMove = false;

        sentences.Clear();

        foreach(dialSen sentence in Dia.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /* The method that displays the next sentence when the player hits the next button. */
    public void DisplayNextSentence() {
        if(sentences.Count == 0) { //There are no more things to show, so close
            EndDialogue();
            return;
        }

        dialSen sentence = sentences.Dequeue();
        nameText.text = sentence.name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.sentence));
    }

    /* A function that makes the sentence show up letter by letter. */
    IEnumerator TypeSentence(string sentence) {
        diaText.text = "";

        foreach(char letter in sentence.ToCharArray()) {
            diaText.text += letter;
            yield return new WaitForSeconds(.03f);
        }
    }

    /* A function that close the UI of the dialogue, meaning the dialogue has ended. */
    public void EndDialogue() {
        if (Variables.WillAdd) {
            Variables.StoryIndex += 1;
            Variables.WillAdd = false;
        }

        FindObjectOfType<Player>().CanMove = true;
        Anim.SetBool("IsOpen", false);
    }
}
