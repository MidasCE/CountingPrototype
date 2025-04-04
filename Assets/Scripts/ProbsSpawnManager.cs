using System.Collections;
using UnityEngine;

public class ProbsSpawnManager : MonoBehaviour
{
    public float spawnLimitZLeft =-5;
    public float spawnLimitZRight = 5;
    
    private const float SpawnPosY = 4;
    public GameObject[] probPrefabs;
    
    private const float SpawnIntervalMin = 1f;
    private const float SpawnIntervalMax = 2f;
    
    
    private Coroutine spawnCoroutine;
    
    public void StartSpawning()
    {
        spawnCoroutine = StartCoroutine(SpawnRandomProbs());
    }

    IEnumerator SpawnRandomProbs()
    {
        float spawnInterval = Random.Range(SpawnIntervalMin, SpawnIntervalMax);
        yield return new WaitForSeconds(spawnInterval);
        
        int index = Random.Range(0, probPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(0, SpawnPosY, Random.Range(spawnLimitZLeft, spawnLimitZRight));

        // instantiate ball at random spawn location
        GameObject spawnedObject = Instantiate(probPrefabs[index], spawnPos, probPrefabs[index].transform.rotation);
        
        // Set this GameObject as the parent
        spawnedObject.transform.SetParent(transform);
    }
    
    public void StopSpawning()
    {
        StopCoroutine(spawnCoroutine);
    }
    
    public void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
