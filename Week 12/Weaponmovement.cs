using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Sprite GunF;
    public Sprite GunB;
    public Sprite GunL;
    public Sprite GunR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.sprite = GunL;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.sprite = GunR;
        }
        else
        {
            speedX = 0;
        }
        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = GunB;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = GunF;
        }
        else
        {
            speedY = 0;
        }
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
