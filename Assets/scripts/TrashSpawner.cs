using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    // CAMBIADO: Se reemplazó "trashPrefab" por un arreglo para aceptar varios tipos de basura
    public GameObject[] trashPrefabs; // <<-- NUEVO (Antes: public GameObject trashPrefab;)

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
        // CAMBIADO: Validación para verificar el arreglo en lugar del único prefab
        if (trashPrefabs == null || trashPrefabs.Length == 0) // <<-- NUEVO
        {
            Debug.LogWarning("Atencion! No has asignado el Prefab de basura en el Spawner.");
            return;
        }

        // AGREGADO: Selección aleatoria de un prefab del arreglo
        int randomIndex = Random.Range(0, trashPrefabs.Length); // <<-- NUEVO
        GameObject selectedPrefab = trashPrefabs[randomIndex]; // <<-- NUEVO

        if (selectedPrefab == null) return; // <<-- NUEVO

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

        // CAMBIADO: Ahora instancía "selectedPrefab" en lugar de "trashPrefab"
        Instantiate(selectedPrefab, spawnPosition, randomRotation); // <<-- MODIFICADO
    }

    // Dibuja una caja verde en la vista Scene para saber donde va a caer la basura
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRangeX * 2, 1f, spawnRangeZ * 2));
    }
}