using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isEnemyShot;
    [SerializeField] private float timeLife;

    public int Damage { get => damage; }
    public bool IsEnemyShot { get => isEnemyShot; }

    private void Start()
    {
        Destroy(gameObject, timeLife);
    }
}
