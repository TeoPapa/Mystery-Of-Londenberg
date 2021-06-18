using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* A simple script for closing canvases */
public class xButton : MonoBehaviour
{
   public GameObject canvas; //The canvas that we want to close

    /* The method that the UI Button has to call in order to close the
     * canvas GameObject
     */
   public void CloseCanvas()
   {
       canvas.SetActive(false);
   }
}
