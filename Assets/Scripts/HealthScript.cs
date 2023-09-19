using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private bool _isEnemy;
    [SerializeField] private List<int> _healthUp = new List<int>();
    public int Health { get => _health; }
    public bool IsEnemy { get => _isEnemy; }

    public Action<GameObject, TypeTank> deadEvent;
    public Action<int> changeHealthEvent;
    public Action<Vector3> shotEvent;

    private void OnEnable()
    {
        GetComponentInChildren<UpgradeTank>().upgradeEvent += ((int a) => SetHealth(_healthUp[a]));
    }
    private void OnDisable()
    {
        GetComponentInChildren<UpgradeTank>().upgradeEvent -= ((int a) => SetHealth(_healthUp[a]));
    }

    public void SetHealth(int value)
    {
        _health = value;
        changeHealthEvent?.Invoke(_health);
    }

    public void Damage(int value)
    {
        if (_health > 0)
        {
            _health -= value; 
            if (_health <= 0) deadEvent?.Invoke(gameObject, _isEnemy ? TypeTank.red : TypeTank.blue);
        }
        else
        {
            _health = 0;
            deadEvent?.Invoke(gameObject, _isEnemy ? TypeTank.red : TypeTank.blue);
        }
        changeHealthEvent?.Invoke(_health);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShotScript shotScript = collision.GetComponent<ShotScript>();        

        if (shotScript != null && shotScript.IsEnemyShot != IsEnemy)
        {
            Damage(shotScript.Damage);
            shotEvent?.Invoke(shotScript.gameObject.transform.position);
            Destroy(shotScript.gameObject);            
        }        
    }
}
