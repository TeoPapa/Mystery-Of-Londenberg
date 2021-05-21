using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Animator anim; //the enemy's animator
    public Rigidbody2D rb; //the enemy's natural body

    public bool isMovingInY = false; //if checked then the player moves in the Y axis, else it auto moves on the X axis

    public float leftCap;
    public float rightCap;
    public float upCap;
    public float downCap;
    public float speed;
    public bool facingLeft = true;
    public bool facingDown = true;
    public Collider2D leftColl;
    public Collider2D rightColl;
    public Collider2D downColl;
    public Collider2D upColl;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isMovingInY)
        {
            //move enemy in Y axis
            MoveY();
        }
        else
        {
            //move enemy in X axis
            MoveX();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerM" || other.gameObject.tag == "PlayerF")
        {
            //checks if the player has been seen and if so resets to the main scene
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void MoveX()
    {
        //handles movement
        if(facingLeft)
        {
            //if the enemy is facing left move him towards the leftCap and adapt its field of view
            if(transform.position.x > leftCap)
            {
                rightColl.enabled = false;
                leftColl.enabled = true;
                anim.Play("EnemyLeftWalk");
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            //if the enemy is facing right move him towards the rightCap and adapt its field of view
            if(transform.position.x < rightCap)
            {
                leftColl.enabled = false;
                rightColl.enabled = true;
                anim.Play("EnemyRightWalk");
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
        //handles movement
        if (facingDown)
        {
            //if the enemy is facing down move him towards the downCap and adapt its field of view
            if (transform.position.y > downCap)
            {
                upColl.enabled = false;
                downColl.enabled = true;
                anim.Play("EnemyDownWalk");
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
            else
            {
                facingDown = false;
            }
        }
        else
        {
            //if the enemy is facing up move him towards the upCap and adapt its field of view
            if (transform.position.y < upCap)
            {
                downColl.enabled = false;
                upColl.enabled = true;
                anim.Play("EnemyUpWalk");
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
            else
            {
                facingDown = true;
            }
        }
    }
}
