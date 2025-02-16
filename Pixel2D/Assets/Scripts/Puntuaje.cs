using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class Puntuaje : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        ControladorPuntos.Instance.sumarPuntosEvnt += CambiarTexto;
    }

    public void CambiarTexto(object sender, ControladorPuntos.SumarPuntosEventArgs e)
    {
        textMeshProUGUI.text = e.puntosActualEvnt.ToString();
    }

}
