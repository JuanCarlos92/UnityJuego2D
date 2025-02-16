using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandera : MonoBehaviour
{
    public int cantidadMonedas;
    public int monedasRecogidas;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cantidadMonedas = GameObject.FindGameObjectsWithTag("Moneda").Length;

    }

    private void ActivarBandera()
    {
        animator.SetTrigger("Activar");
    }

    public void MonedasRecogidas()
    {
        monedasRecogidas += 1;

        if (monedasRecogidas == cantidadMonedas)
        {
            ActivarBandera();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && monedasRecogidas == cantidadMonedas)
        {
            //cambiarEscena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
