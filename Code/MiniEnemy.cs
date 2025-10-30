using UnityEngine;

public class MiniEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player != null)
            {
                Player.TakeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player != null)
            {
                Player.TakeDamage(stayDamage);
            }
        }
    }
}
