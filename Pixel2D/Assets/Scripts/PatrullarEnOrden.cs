using UnityEngine;

public class PatrullarEnOrden : MonoBehaviour
{
    public float velocidadMovimiento;
    public Transform[] puntosMovimientos;
    public float distanciaMinima;

    private int siguientePaso = 0;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimientos[siguientePaso].position, velocidadMovimiento * Time.deltaTime);

        if(Vector2.Distance(transform.position, puntosMovimientos[siguientePaso].position)< distanciaMinima)
        {
            siguientePaso += 1;
            if(siguientePaso >= puntosMovimientos.Length)
            {
                siguientePaso = 0;
            }
            Girar();
        }
    }

    private void Girar()
    {
        if(transform.position.x < puntosMovimientos[siguientePaso].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;

        }
    }
}
