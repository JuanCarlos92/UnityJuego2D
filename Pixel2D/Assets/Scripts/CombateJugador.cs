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

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        

        if (vida > 0)
        {
            animator.SetTrigger("Da�o");
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

    public void TomarDa�o(float da�o, Vector2 posicion)
    {
        vida -= da�o;
        barraDeVida.CambiarVidaActual(vida);
        if (vida > 0)
        {
            animator.SetTrigger("Da�o");
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
