using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2D;

    public bool sePuedeMover = true;
    public Vector2 velocidadRebote;

    [Header("Movimiento")]
    public float velocidadDeMovimiento;
    [Range(0, 0.3f)] public float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private float movimientoHorizontal = 0f;

    [Header("Salto")]
    public float fuerzaDeSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;

    private bool salto = false;


    public float attackRange = 1.5f;
    public int attackDamage = 10;
    public LayerMask enemyLayers;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        animator.SetFloat("VelocidadY", rb2D.linearVelocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if(mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if(mover < 0 && mirandoDerecha)
        {
            Girar();

        }
        if(enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb2D.linearVelocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, velocidadRebote.y);
    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }


    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);

        if (sePuedeMover)
        {
             Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        }


        salto = false;


    }

    //Para visualizar el área de la caja 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
