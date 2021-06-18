using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* The class that sends the player to the Credits */
public class GoToCredits: MonoBehaviour
{
    /* Upon collision sent the player to the
     * Credits scene (and add volume to the music) */
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("PlayerM") || collision.CompareTag("PlayerF")) {
            FindObjectOfType<AudioSource>().volume = 0.20f;
            SceneManager.LoadScene("Credits");
        }
    }
}
