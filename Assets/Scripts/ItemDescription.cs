using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* The class tat keeps the description of the item */
public class ItemDescription : MonoBehaviour
{
    public string description; //The description of the item
    public Text text; //The text box that the description will appear
    public GameObject canvas; //The canvas which the text box is

    void Start()
    {
        //Be sure that the canvas is closed
        canvas.SetActive(false);
    }


    /* A method for showing the description on the text box */
    public void ShowDescription()
    {
        text.text = description;
    }


    /* A method that shows the description on a bigger canvas/text box */
    public void ShowDescriptionOnNote()
    {
        canvas.SetActive(true);
        text.text = description;
    }
}
