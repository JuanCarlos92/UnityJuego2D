using UnityEngine;

public class Coin : MonoBehaviour
{
    public int cantidadPuntos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Bandera").GetComponent<Bandera>().MonedasRecogidas();
            ControladorPuntos.Instance.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
        }
    }
}
