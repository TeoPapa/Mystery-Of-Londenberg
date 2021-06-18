using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A class that when is added on an item it keeps it from getting destroyed
 * (used for the music) */
public class KeepTheSongPlaying : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
