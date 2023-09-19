using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private List<WeaponScript> _weaponScripts;

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
        foreach (WeaponScript ws in _weaponScripts)
        {
            if (ws.enabled) ws.Shot(transform.rotation, transform.parent);
        }        
    }

    private void ActivateCannon(int level)
    {
        if (level == 0)
        {
            _weaponScripts[0].enabled = true;
            _weaponScripts[1].enabled = false;
            _weaponScripts[2].enabled = false;
            _weaponScripts[3].enabled = false;
        }
        if (level == 1)
        {
            _weaponScripts[3].enabled = true;
        }
        if (level == 2)
        {
            _weaponScripts[0].enabled = false;
            _weaponScripts[1].enabled = true;
            _weaponScripts[2].enabled = true;
            _weaponScripts[3].enabled = true;
        }
    }
}
