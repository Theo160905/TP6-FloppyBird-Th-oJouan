using System.Collections;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;

    [SerializeField]
    private Transform spawnPoint; 

    void Start()
    {
        if (prefabToSpawn != null && spawnPoint != null)
        {
            StartCoroutine(SpawnPrefab());
        }
        else
        {
            Debug.LogError("Prefab ou point de spawn non défini !");
        }
    }

    IEnumerator SpawnPrefab()
    {
        yield return new WaitForSeconds(2.0f);
        while (true) { 
            SpawnObstacles();
            yield return new WaitForSeconds(2.0f);
        }
    }

    void SpawnObstacles()
    {
        Vector2 Spawnposition = spawnPoint.position;
        Spawnposition.y = Random.Range(-2f, 2f);

        GameObject newPrefabInstance = Instantiate(prefabToSpawn, Spawnposition, Quaternion.identity);
    }
}
