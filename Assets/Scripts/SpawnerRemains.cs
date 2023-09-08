using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRemains : MonoBehaviour
{
    [SerializeField] private GameObject remainsPrefab;
    [SerializeField] private float timeRandomSpawnMin;
    [SerializeField] private float timeRandomSpawnMax;
    [SerializeField] private float chanceSpawn;
    [SerializeField] private Transform borderLD;
    [SerializeField] private Transform borderUR;
    [SerializeField] private Transform parent;
    private Coroutine randomSpawnRemains;
    private List<GameObject> remainsAll = new List<GameObject>();
    public void StartSpawn()
    {
        randomSpawnRemains = StartCoroutine(RandomSpawnRemains());
    }
    public void StopSpawn()
    {
        StopCoroutine(randomSpawnRemains);
    }

    private void SpawnRemains(Vector3 position, Transform parent, float chance)
    {
        GameObject remains;
        if (Random.Range(0f, 100f) < chance)
        {
            remains = Instantiate(remainsPrefab, position, Quaternion.identity, parent);
            remains.transform.position = new Vector3(remains.transform.position.x, remains.transform.position.y, parent.position.z);
            remains.GetComponent<MetalRemains>().destroyRemainsEvent += DestroyRemains;
            remainsAll.Add(remains);
        } 
    }

    private IEnumerator RandomSpawnRemains()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(timeRandomSpawnMin, timeRandomSpawnMax));
            SpawnRemains(new Vector3(Random.Range(borderLD.position.x, borderUR.position.x), Random.Range(borderLD.position.y, borderUR.position.y), parent.transform.position.z), parent, 100);
        }        
    }

    public void SpawnAfterTankDead(Vector3 position)
    {
        SpawnRemains(position, parent, chanceSpawn);
    }

    public void DestroyRemains(GameObject remains)
    {
        remainsAll.Remove(remains);
        remains.GetComponent<MetalRemains>().destroyRemainsEvent += DestroyRemains;
        Destroy(remains);
    }

    public void DestroyAllRemains()
    {
        List<GameObject> remainsAllCopy = new List<GameObject>(remainsAll);
        foreach (GameObject remains in remainsAllCopy)
        {
            remainsAll.Remove(remains);
            Destroy(remains);
        }
    }
}
