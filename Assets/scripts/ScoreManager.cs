using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Configuración de UI")]
    public TextMeshProUGUI textoPuntos;

    private int puntosActuales = 0;

    private void Awake()
    {
        // Patron Singleton sencillo para acceder facilmente desde cualquier script
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ActualizarTexto();
    }

    public void AgregarPuntos(int cantidad)
    {
        puntosActuales += cantidad;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        if (textoPuntos != null)
        {
            textoPuntos.text = "Puntos: " + puntosActuales;
        }
    }
}