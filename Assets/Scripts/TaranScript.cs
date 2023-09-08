using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaranScript : MonoBehaviour
{
    [SerializeField] private HealthScript healthScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthScript healthScript = collision.GetComponent<TaranScript>().healthScript;

        if (healthScript != null && healthScript.IsEnemy != this.healthScript.IsEnemy)
        {
            healthScript.Damage(1);
            this.healthScript.Damage(1);
        }
    }
}
