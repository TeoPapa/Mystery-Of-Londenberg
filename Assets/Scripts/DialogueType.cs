using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* The class where you set the Name of the dialogue item and the Sentences that this holds. */

[System.Serializable]
public class DialogueType
{
    public dialSen[] sentences; //The sentences of the dialogue
}

[System.Serializable]
public class dialSen {
    public string name; //The name that will show up

    [TextArea(5, 10)]
    public string sentence; //The sentence that will show up
}