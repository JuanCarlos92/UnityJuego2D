using UnityEngine;

public class SeguirJugadorArea : MonoBehaviour
{

    public float radioBusqueda;  // Rango para detectar jugador
    public LayerMask capaJugador; // Capa del Jugador
    public Transform transformJugador; 
    public float velocidadMovimiento;
    public float distanciaMaxima;
    public Vector3 puntoInicial;
    public bool mirandoDerecha;

    public EstadosMovimiento estadoActual; // Estado actual del enemigo

    //Enum con los estados del enemigo
    public enum EstadosMovimiento
    {
        Esperando,
        Siguiendo,
        Volviendo,
    }
    private void Start()
    {
        puntoInicial = transform.position;
    }

    private void Update()
    {
        switch (estadoActual)
        {
            case EstadosMovimiento.Esperando:
                EstadoEsperando();
                break;
            case EstadosMovimiento.Siguiendo:
                EstadoSiguiendo();
                break;
            case EstadosMovimiento.Volviendo:
                EstadoVolviendo();
                break;
        }

    }

    private void EstadoEsperando()
    {       
        // Generamos el circulo (psicion enemigo, radio, capa del jugador)
            Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);
        //Si colisionamos con jugador....
            if (jugadorCollider)
            {
                transformJugador = jugadorCollider.transform;
                estadoActual = EstadosMovimiento.Siguiendo; //Si encuentra al jugador = siguiendo
            }
       
    }

    private void EstadoSiguiendo()
    {
        //Si es null...
        if (transformJugador == null) 
        {
            estadoActual = EstadosMovimiento.Volviendo; // Vuelve y salte de la ejecucion
            return;
        }
        //Si no es null... movemos el objeto en su direccion (Posicion enemigo, posicion del jugador, velocidad a la que va a ir)
        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);

        GirarAObjetivo(transformJugador.position);

        //Saber cuando cambiar de estado ( cuando el objeto esta lejos de su posicionIncial o el jugador se aleja demasiado
        if (Vector2.Distance(transform.position,puntoInicial) > distanciaMaxima||
            Vector2.Distance(transform.position, transformJugador.position) > distanciaMaxima)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            transformJugador = null;
        }
        
    }

    private void EstadoVolviendo()
    {
        // movemos el objeto a la posicion inicial (Posicion enemigo, posicionInicial , velocidad a la que va a ir)
        transform.position = Vector2.MoveTowards(transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);

        GirarAObjetivo(puntoInicial);

        if (Vector2.Distance(transform.position, puntoInicial)< 0.1f)
        {
            estadoActual = EstadosMovimiento.Esperando;
        }
    }

    private void GirarAObjetivo(Vector3 objetivo)
    {
        if(objetivo.x > transform.position.x && !mirandoDerecha)
        {
            Girar();

        }else if (objetivo.x < transform.position.x && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    //Pintamos el circulo (visual)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
        Gizmos.DrawWireSphere(puntoInicial, distanciaMaxima);
    }

}
