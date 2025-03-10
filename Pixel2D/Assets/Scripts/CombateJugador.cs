using System.Collections;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    public float vida;
    public float vidaMaxima;
    public BarraDeVida barraDeVida;
    public float tiempoPerdidaControl;

    private PjScript movimientoJugador;
    private Animator animator;


    private void Start()
    {
        movimientoJugador = GetComponent<PjScript>();
        animator = GetComponent<Animator>();

        vida = vidaMaxima;
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        

        if (vida > 0)
        {
            animator.SetTrigger("Daño");
        }
        else
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        movimientoJugador.sePuedeMover = false;
        Destroy(gameObject, 10f);
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida > 0)
        {
            animator.SetTrigger("Daño");
            StartCoroutine(PerderControl());
            StartCoroutine(DesactivarColision());
            movimientoJugador.Rebote(posicion);
        }
        else
        {
            Muerte();
        }
    }
    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(6,7, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }

    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;

    }
}
