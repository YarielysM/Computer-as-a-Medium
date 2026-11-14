
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public Sprite AlienF;
    public Sprite AlienB;

    private float speedX;
    private float speedY;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        speedX = 0;
        speedY = 0;

        if (Keyboard.current.aKey.isPressed)
            speedX = -1;

        if (Keyboard.current.dKey.isPressed)
            speedX = 1;

        if (Keyboard.current.wKey.isPressed)
            speedY = 1;

        if (Keyboard.current.sKey.isPressed)
            speedY = -1;

        // Horizontal animations
        if (speedX != 0)
        {
            animator.SetBool("walk", true);

            // Flip the walking animation
            spriteRenderer.flipX = speedX < 0;
        }
        // Vertical sprites
        else if (speedY > 0)
        {
            animator.SetBool("walk", false);
            spriteRenderer.sprite = AlienB;
        }
        else if (speedY < 0)
        {
            animator.SetBool("walk", false);
            spriteRenderer.sprite = AlienF;
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(speedX, speedY).normalized;
        rb.linearVelocity = movement * moveSpeed;
    }
}

