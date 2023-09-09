using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private List<WeaponScript> weaponScripts;

    private void OnEnable()
    {
        GetComponentInChildren<UpgradeTank>().upgradeEvent += ActivateCannon;
    }
    private void OnDisable()
    {
        GetComponentInChildren<UpgradeTank>().upgradeEvent -= ActivateCannon;
    }

    private void Update()
    {
        foreach (WeaponScript ws in weaponScripts)
        {
            if (ws.enabled) ws.Shot(transform.rotation, transform.parent);
        }        
    }

    private void ActivateCannon(int level)
    {
        if (level == 0)
        {
            weaponScripts[0].enabled = true;
            weaponScripts[1].enabled = false;
            weaponScripts[2].enabled = false;
            weaponScripts[3].enabled = false;
        }
        if (level == 1)
        {
            weaponScripts[3].enabled = true;
        }
        if (level == 2)
        {
            weaponScripts[0].enabled = false;
            weaponScripts[1].enabled = true;
            weaponScripts[2].enabled = true;
            weaponScripts[3].enabled = true;
        }
    }
}
