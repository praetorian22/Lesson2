using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isEnemy;
    [SerializeField] private List<int> healthUp = new List<int>();
    public int Health { get => health; }
    public bool IsEnemy { get => isEnemy; }

    public Action<GameObject, TypeTank> deadEvent;
    public Action<int> changeHealthEvent;
    public Action<Vector3> shotEvent;

    private void OnEnable()
    {
        GetComponentInChildren<UpgradeTank>().upgradeEvent += ((int a) => SetHealth(healthUp[a]));
    }
    private void OnDisable()
    {
        GetComponentInChildren<UpgradeTank>().upgradeEvent -= ((int a) => SetHealth(healthUp[a]));
    }

    public void SetHealth(int value)
    {
        health = value;
        changeHealthEvent?.Invoke(health);
    }

    public void Damage(int value)
    {
        if (health > 0)
        {
            health -= value; 
            if (health <= 0) deadEvent?.Invoke(gameObject, isEnemy ? TypeTank.red : TypeTank.blue);
        }
        else
        {
            health = 0;
            deadEvent?.Invoke(gameObject, isEnemy ? TypeTank.red : TypeTank.blue);
        }
        changeHealthEvent?.Invoke(health);
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
