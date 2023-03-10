using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character moves
    private Vector3 change; // player movement direction
    private Rigidbody2D rb2d;
    private Animator anim;
    private Renderer rend;
    float jumpHeight = 2f; // The height of the jump
    private bool isJumping = false; // Flag for whether the character is currently jumping
    private float jumpTime = 0f; // The time the character has been jumping for
    private float jumpDuration = 0.5f; // The total duration of the character's jump
    
public GameObject torso;

    void Start () 
    {
        anim = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<Renderer> ();
        rb2d = GetComponent<Rigidbody2D>();   
    }

    // void PickUpKey()
    // {
    //     // Get all colliders overlapping with the player's collider
    //     // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRange, default);

    //     // // Loop through all the colliders and check if they're key objects
    //     // foreach (Collider2D collider in colliders)
    //     // {
    //     //     if (collider.CompareTag("Key"))
    //     //     {
    //     //         Destroy(collider.gameObject); // Destroy the key object
    //     //         // implement updating key count
    //     //     }
    //     // }
    // }

    // Update is called once per framex
    void Update()
    {
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();

        if (Input.GetAxis ("Horizontal") > 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = 1.0f;
            transform.localScale = newScale;
        }
        else if (Input.GetAxis ("Horizontal") < 0){
                Vector3 newScale =transform.localScale;
                newScale.x = -1.0f;
                transform.localScale = newScale;
        }


        if (Input.GetKey("c")){
            anim.SetBool("Crouch", true);
            torso.SetActive(false);
        } else {
            anim.SetBool("Crouch", false);
            torso.SetActive(true);
        }

         // Make the character jump when the user presses the spacebar
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTime = 0f;
        }

        // If the character is currently jumping
        if (isJumping)
        {
            // Calculate the height of the character's jump based on the time spent jumping
            float jumpProgress = jumpTime / jumpDuration;
            float jumpHeightOffset = jumpHeight * (1f - Mathf.Pow(jumpProgress - 1f, 2f));

            // Move the character up by the height of its jump
            transform.position += Vector3.up * jumpHeightOffset * Time.deltaTime;

            // Increment the jump time
            jumpTime += Time.deltaTime;

            // If the character has finished jumping, reset the jumping flag
            if (jumpTime >= jumpDuration)
            {
                isJumping = false;
            }
        }

    }

    void UpdateAnimationAndMove() {

        change = Vector3.zero;
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");

        if (change != Vector3.zero) {
            rb2d.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
        }
    }
}

