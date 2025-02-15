using UnityEngine;

public class Patrullar : MonoBehaviour
{
    public float velocidadMovimiento;
    public Transform[] puntosMovimientos;
    public float distanciaMinima;

    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimientos.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimientos[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);

        if(Vector2.Distance(transform.position, puntosMovimientos[numeroAleatorio].position)< distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimientos.Length);
            Girar();
        }
    }

    private void Girar()
    {
        if(transform.position.x < puntosMovimientos[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;

        }
    }
}
