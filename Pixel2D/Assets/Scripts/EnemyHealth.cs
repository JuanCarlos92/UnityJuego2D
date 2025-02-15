using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 30;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(name + " recibió " + damage + " de daño. Vida restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(name + " ha muerto.");
        Destroy(gameObject);
    }
}

