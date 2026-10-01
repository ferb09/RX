using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    // El Prefab de la basura (tu cubo/esfera con XR Grab Interactable)
    public GameObject trashPrefab;

    // Tiempo en segundos entre cada aparicion de basura
    public float spawnInterval = 3.0f;

    // Area de generacion (distancia hacia los lados)
    public float spawnRangeX = 5.0f;
    public float spawnRangeZ = 5.0f;

    void Start()
    {
        // Inicia la generacion automatica de basura repetidamente
        InvokeRepeating(nameof(SpawnTrash), 1.0f, spawnInterval);
    }

    void SpawnTrash()
    {
        if (trashPrefab == null)
        {
            Debug.LogWarning("Atencion! No has asignado el Prefab de basura en el Spawner.");
            return;
        }

        // Calcula una posicion aleatoria alrededor del Spawner
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 spawnPosition = new Vector3(
            transform.position.x + randomX,
            transform.position.y,
            transform.position.z + randomZ
        );

        // Genera la basura con una rotacion aleatoria
        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(0f, 360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f)
        );

        Instantiate(trashPrefab, spawnPosition, randomRotation);
    }

    // Dibuja una caja verde en la vista Scene para saber donde va a caer la basura
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRangeX * 2, 1f, spawnRangeZ * 2));
    }
}