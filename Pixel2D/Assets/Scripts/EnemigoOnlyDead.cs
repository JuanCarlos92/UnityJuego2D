using UnityEngine;

public class EnemigoOnlyDead : MonoBehaviour
{
    public float vida;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDamage(float damage)
    {
        vida -= damage;

        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CombateJugador>().TomarDaño(20, other.GetContact(0).normal);

        }
    }

}
