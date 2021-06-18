using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*The class that handles the enemy behaviour */
public class Enemy : MonoBehaviour
{
    public Animator anim; //The enemy's animator
    public Rigidbody2D rb; //The enemy's natural body

    public bool isMovingInY = false; //If checked then the player moves in the Y axis, else it auto moves on the X axis

    public float leftCap; //The max the enemy can move on the left
    public float rightCap; //The max the enemy can move on the right
    public float upCap; //The max the enemy can move up
    public float downCap; //The max the enemy can move down
    public float speed; //The movement speed of the enemy
    public bool facingLeft = true; //Is the enemy facing left
    public bool facingDown = true; //Is the enemy facing down
    public Collider2D leftColl; //The collider on the left
    public Collider2D rightColl; //The collider on the right
    public Collider2D downColl; //The collider down
    public Collider2D upColl; //The collider up

    public Vector2 PositionToGo; //Where will the player get teleported
    public Animator transitionAnim; //The animation of the teleport

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isMovingInY)
        {
            //Move enemy in Y axis
            MoveY();
        }
        else
        {
            //Move enemy in X axis
            MoveX();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerM" || other.gameObject.tag == "PlayerF")
        {
            //Checks if the player has been seen and if so resets him to a certain point in the map
            StartCoroutine(ChangeIt());
        }
    }

    private void MoveX()
    {
        //Handles movement
        if(facingLeft)
        {
            //If the enemy is facing left move him towards the leftCap and adapt its field of view
            if(transform.position.x > leftCap)
            {
                rightColl.enabled = false;
                leftColl.enabled = true;
                anim.Play("policemanLeftWalk");
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            //If the enemy is facing right move him towards the rightCap and adapt its field of view
            if(transform.position.x < rightCap)
            {
                leftColl.enabled = false;
                rightColl.enabled = true;
                anim.Play("policemanRightWalk");
                rb.velocity = new Vector2(speed, 0);    
            }
            else
            {
                facingLeft = true;
            }
        }
    }

    private void MoveY()
    {
        //Handles movement
        if (facingDown)
        {
            //If the enemy is facing down move him towards the downCap and adapt its field of view
            if (transform.position.y > downCap)
            {
                upColl.enabled = false;
                downColl.enabled = true;
                anim.Play("policemanFrontWalk");
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
            else
            {
                facingDown = false;
            }
        }
        else
        {
            //If the enemy is facing up move him towards the upCap and adapt its field of view
            if (transform.position.y < upCap)
            {
                downColl.enabled = false;
                upColl.enabled = true;
                anim.Play("policemanBackWalk");
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
            else
            {
                facingDown = true;
            }
        }
    }

    /* The coroutine for transitioning the player from one location to another */
    IEnumerator ChangeIt()
    {
        FindObjectOfType<Settings>().Transition.SetBool("Transition", true);

        yield return new WaitForSeconds(1);

        FindObjectOfType<Player>().Teleport(PositionToGo);

        yield return new WaitForSeconds(1);

        FindObjectOfType<Settings>().Transition.SetBool("Transition", false);
    }
}
