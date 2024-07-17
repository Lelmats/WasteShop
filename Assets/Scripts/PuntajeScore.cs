using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PuntajeScore : MonoBehaviour
{
    public static int Puntaje = 0; // Puntaje inicial
    public TextMeshPro textoDinero; // Referencia al Texto UI que mostrará el puntaje

    private void Start()
    {
        ActualizarTextoPuntaje();
    }

    // Método para actualizar el puntaje
    public void ActualizarPuntaje(int cantidad)
    {
        Puntaje += cantidad;
        ActualizarTextoPuntaje();
    }

    // Método para actualizar el texto del puntaje en el UI
    private void ActualizarTextoPuntaje()
    {
        if (textoDinero != null)
        {
            // textoPuntaje.text = "Puntaje: " + puntaje.ToString();
            textoDinero.text = Puntaje.ToString(); 

        }
        else
        {
            Debug.LogWarning("No se ha asignado un objeto Texto para mostrar el puntaje.");
        }
    }
}