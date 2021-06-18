using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The class that changes the position of the player */
public class ChangeScene : MonoBehaviour
{
    public Vector2 PositionToGo; //Where will the player go

    public Animator anim; //The animator of the fade

    /*Upon collision, teleport the player */
    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(ChangeIt());
    }

    /* The coroutine that makes the fade from one place to another unnoticable */
    IEnumerator ChangeIt() {
        anim.SetBool("Transition", true);

        yield return new WaitForSeconds(1);

        FindObjectOfType<Player>().Teleport(PositionToGo);

        yield return new WaitForSeconds(1);

        anim.SetBool("Transition", false);
    }
}
