using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraDesaparece : MonoBehaviour
{
    [Header("Configuración")]
    public string tagBasura = "Basura";
    public int puntosPorBasura = 10;

    [Header("Efectos (Opcional)")]
    public AudioClip sonidoDeposito;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entro es basura
        if (other.CompareTag(tagBasura))
        {
            // Suma puntos
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AgregarPuntos(puntosPorBasura);
            }

            // Reproduce sonido opcional
            if (audioSource != null && sonidoDeposito != null)
            {
                AudioSource.PlayClipAtPoint(sonidoDeposito, transform.position);
            }

            // Destruye el objeto de basura
            Destroy(other.gameObject);
        }
    }
}
