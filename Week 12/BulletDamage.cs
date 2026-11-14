using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponentInParent<Enemy>();

            if (enemy != null)
            {
                enemy.enemyHealth -= damage;
            }
        }
    }
} 