using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public string description;
    public Text text;

    public void ShowDescription()
    {
        text.text = description;
    }
}
