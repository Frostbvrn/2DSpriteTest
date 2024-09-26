using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player; // Assign your player object in the Inspector
    public float moveSpeed = 5f; // Speed of movement

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D keys
        float moveY = Input.GetAxis("Vertical");   // W/S keys

        Vector3 movement = new Vector3(moveX, moveY, 0).normalized * moveSpeed * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            // Move the player
            player.transform.position += movement;

            // Flip the sprite based on movement direction
            if (moveX < 0) // Moving left
            {
                spriteRenderer.flipX = true; // Flip the sprite
            }
            else if (moveX > 0) // Moving right
            {
                spriteRenderer.flipX = false; // Unflip the sprite
            }

            // Set walking animation
            animator.SetBool("IsWalking", true);
        }
        else
        {
            // Set idle animation (first frame)
            animator.SetBool("IsWalking", false);
        }
    }
}
