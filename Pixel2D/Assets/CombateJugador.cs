using System.Collections;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    public float vida;
    public float tiempoPerdidaControl;

    private PjScript movimientoJugador;
    private Animator animator;


    private void Start()
    {
        movimientoJugador = GetComponent<PjScript>();
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
    }

    public void TomarDaño(float daño, Vector2 posicion)
    {
        vida -= daño;
        animator.SetTrigger("Daño");
        StartCoroutine(PerderControl());
        StartCoroutine(DesactivarColision());
        movimientoJugador.Rebote(posicion);
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
