using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The class used for the inventory */
public class Inventory : MonoBehaviour
{
    public bool[] isFull; //One boolean for each slot, that shows if the slot is available
    public GameObject[] slots; //The slots available in the inventory
}
