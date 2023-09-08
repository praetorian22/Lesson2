using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private float timeReloadMin;
    [SerializeField] private float timeReloadMax;
    [SerializeField] private Transform pointToShot;
    

    private bool readyToShot;    

    private void Start()
    {
        readyToShot = true;
    }

    public IEnumerator ReloadTimer()
    {
        readyToShot = false;
        yield return new WaitForSeconds(Random.Range(timeReloadMin, timeReloadMax));
        readyToShot = true;
    }

    public void Shot(Quaternion rotation, Transform parent)
    {
        if (readyToShot)
        {
            GameObject shot = Instantiate(shotPrefab, pointToShot.position, rotation, parent);            
            StartCoroutine(ReloadTimer());
        }
    }
}
