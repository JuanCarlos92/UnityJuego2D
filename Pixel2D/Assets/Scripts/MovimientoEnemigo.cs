using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float velocidadMovimiento;
    public float distancia;
    public LayerMask queEsSuelo;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb2D.linearVelocity = new Vector2(-velocidadMovimiento * transform.right.x, rb2D.linearVelocity.y);

        RaycastHit2D informacionSuelo = Physics2D.Raycast(transform.position, -transform.right, distancia, queEsSuelo);


        if (informacionSuelo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - transform.right * distancia);

    }
}
