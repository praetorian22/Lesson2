using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerTanks: MonoBehaviour
{
    private EffectManager effectManager;
    [SerializeField] private GameObject blueTankPrefab;
    [SerializeField] private GameObject redTankPrefab;
    [SerializeField] private Transform parent;    
    public List<GameObject> BlueTanks = new List<GameObject>();
    public List<GameObject> RedTanks = new List<GameObject>();

    public Action<TypeTank, int> tankCountChangeEvent;
    public Action<Vector3> tankDeadEvent;

    private void Start()
    {
        effectManager = GetComponent<EffectManager>();
    }

    public void SpawnTank(TypeTank typeTank, Vector3 position)
    {
        GameObject tank;
        if (typeTank == TypeTank.blue)
        {
            tank = Instantiate(blueTankPrefab, position, Quaternion.identity, parent);
            BlueTanks.Add(tank);
            tankCountChangeEvent?.Invoke(typeTank, BlueTanks.Count);            
        }
        else
        {
            tank = Instantiate(redTankPrefab, position, Quaternion.identity, parent);
            RedTanks.Add(tank);
            tankCountChangeEvent?.Invoke(typeTank, RedTanks.Count);
        }
        tank.GetComponent<HealthScript>().deadEvent += DestroyTank;
        tank.GetComponent<HealthScript>().shotEvent += effectManager.ExplosionMini;
    }

    public void DestroyTank(GameObject gameObject, TypeTank typeTank)
    {        
        if (typeTank == TypeTank.red)
        {
            RedTanks.Remove(gameObject);
            tankCountChangeEvent?.Invoke(typeTank, RedTanks.Count);
        }
        if (typeTank == TypeTank.blue)
        {
            BlueTanks.Remove(gameObject);
            tankCountChangeEvent?.Invoke(typeTank, BlueTanks.Count);
        }
        tankDeadEvent?.Invoke(gameObject.transform.position);
        Destroy(gameObject);
    }

    public void DestroyAllTank()
    {
        List<GameObject> BlueTanksCopy = new List<GameObject>(BlueTanks);
        List<GameObject> RedTanksCopy = new List<GameObject>(RedTanks);
        foreach (GameObject tank in BlueTanksCopy)
        {
            Destroy(tank);
            BlueTanks.Remove(tank);
        }
        foreach (GameObject tank in RedTanksCopy)
        {
            Destroy(tank);
            BlueTanks.Remove(tank);
        }
    }
}

public enum TypeTank
{
    red, 
    blue,
}