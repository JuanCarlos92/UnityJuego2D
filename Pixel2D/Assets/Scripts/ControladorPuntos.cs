using System;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;
    public int puntosActual;
    public int puntosMaximo;
    public event EventHandler<SumarPuntosEventArgs> sumarPuntosEvnt;

    public class SumarPuntosEventArgs : EventArgs
    {
        public int puntosActualEvnt;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

   // private void Start()
   // {
        // Guardar puntuacion
        //puntosMaximo = PlayerPrefs.GetInt("PuntosMaximo");
   // }

    public void SumarPuntos(int puntos)
    {
        puntosActual += puntos;
        if(puntosActual > puntosMaximo)
        {
            puntosMaximo = puntosActual;
            //PlayerPrefs.SetInt("PuntosMaximo", puntosMaximo);
        }

        sumarPuntosEvnt?.Invoke(this, new SumarPuntosEventArgs { puntosActualEvnt = puntosActual });
    }
}
