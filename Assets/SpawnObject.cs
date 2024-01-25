using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint; 

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

    private IEnumerator SpawnPrefab()
    {
        while (true) { 
            SpawnObstacle();
            yield return new WaitForSeconds(3.0f);
        }
    }

    private void SpawnObstacle()
    {
        GameObject newPrefabInstance = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
