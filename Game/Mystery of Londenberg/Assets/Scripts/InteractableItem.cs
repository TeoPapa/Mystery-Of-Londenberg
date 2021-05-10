using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{

    public bool IsInRange; //The boolean that checks if the player is in range
    public KeyCode InteractKey; //The interaction key
    public UnityEvent InteractAction; //The InteractAction that will hold what the interact will be

    // Update is called once per frame
    void Update()
    {

        
        /* Checks if the player is in range, then if the player has interacted with the item,
         * then invoke the InteractAction */
        if (IsInRange)
        {
            if (Input.GetKeyDown(InteractKey))
            {
                InteractAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            IsInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            IsInRange = false;
    }
}
