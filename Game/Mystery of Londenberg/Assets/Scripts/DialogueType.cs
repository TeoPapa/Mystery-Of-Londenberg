using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * The class where you set the Name of the dialogue item and the Sentences that this holds.
 */
[System.Serializable]
public class DialogueType
{
    public string name;

    [TextArea(5, 10)]
    public string[] sentences;
}
