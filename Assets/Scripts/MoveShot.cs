using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShot : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 movement;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }   

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
