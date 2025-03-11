using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Prefab del enemigo
    [SerializeField] private Transform[] spawnPoints; // Array de puntos de spawn

    private float elapsedTime = 0;
    [SerializeField] private int spawnInterval = 5; // Tiempo entre spawns

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            elapsedTime = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No hay puntos de spawn asignados.");
            return;
        }

        // Selecciona un punto de spawn aleatorio
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        // Instancia el enemigo en ese punto
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
