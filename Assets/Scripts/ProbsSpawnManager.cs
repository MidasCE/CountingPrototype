using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbsSpawnManager : MonoBehaviour
{
    public float spawnLimitZLeft = -4;
    public float spawnLimitZRight = 4;
    
    private const float SpawnPosY = 4;
    public GameObject[] probPrefabs;
    
    private const float SpawnIntervalMin = 1f;
    private const float SpawnIntervalMax = 2f;
    
    private Coroutine _spawnCoroutine;
    private readonly List<GameObject> _spawnedObjects = new();
    
    public void StartSpawning()
    {
        _spawnCoroutine = StartCoroutine(SpawnRandomProbs());
    }

    private IEnumerator SpawnRandomProbs()
    {
        while (true)
        {
            float spawnInterval = Random.Range(SpawnIntervalMin, SpawnIntervalMax);
            yield return new WaitForSeconds(spawnInterval);

            if (_spawnedObjects.Count >= 10)
            {
                Destroy(_spawnedObjects[0]);
                _spawnedObjects.RemoveAt(0);
            }
        
            int index = Random.Range(0, probPrefabs.Length);
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(0, SpawnPosY, Random.Range(spawnLimitZLeft, spawnLimitZRight));

            // instantiate ball at random spawn location
            GameObject spawnedObject = Instantiate(probPrefabs[index], spawnPos, probPrefabs[index].transform.rotation);
        
            // Set this GameObject as the parent
            spawnedObject.transform.SetParent(transform);
        
            _spawnedObjects.Add(spawnedObject);
        }
    }
    
    public void StopSpawning()
    {
        StopCoroutine(_spawnCoroutine);
    }
    
    public void DestroyAllChildren()
    {
        foreach (GameObject child in _spawnedObjects)
        {
            Destroy(child);
        }
        _spawnedObjects.Clear();
    }
    
}
