using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
        MoveFirePoint(); 
        Shoot();
    }
    void Attack()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }
    void MoveFirePoint()
    {
        Vector2 movement = Vector2.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            movement.x += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            movement.x -= 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            movement.y += 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            movement.y -= 1;
        }


        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * 
     Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
    void Shoot()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}