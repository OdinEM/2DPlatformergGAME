using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float jumpPower = 12f; // Jump force
    public Transform groundCheckPosition; // Position to check if the player is grounded
    public LayerMask groundLayer; // Layer to identify the ground

    private Rigidbody2D myBody;
    private Animator anim;
    private bool isGrounded;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>(); // Initialize Rigidbody2D
        anim = GetComponent<Animator>(); // Initialize Animator
    }

    void Update()
    {
        CheckIfGrounded(); // Check if the player is grounded
        PlayerJump(); // Handle jumping
    }

    void FixedUpdate()
    {
        PlayerWalk(); // Handle movement
    }

    void PlayerWalk()
    {
        float h = Input.GetAxis("Horizontal"); // Use "Horizontal" axis for movement (arrow keys or A/D)

        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y); // Move right
            ChangeDirection(1); // Face right
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y); // Move left
            ChangeDirection(-1); // Face left
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y); // Stop moving
        }

        anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x)); // Update animation speed
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction; // Flip the player's scale to face the correct direction
        transform.localScale = tempScale;
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);

        // Update the animator if needed
        anim.SetBool("Jump", !isGrounded);
    }

    void PlayerJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Jump only if grounded and Spacebar is pressed once
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpPower); // Apply jump force
            anim.SetBool("Jump", true); // Trigger jump animation
        }
    }
}