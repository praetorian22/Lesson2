using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptForBot : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 targetMovement;

    [SerializeField] private float speed;
    [SerializeField] private float timeRepositionMin;
    [SerializeField] private float timeRepositionMax;    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Reposition()
    {
        while (true)
        {
            targetMovement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            yield return new WaitForSeconds(Random.Range(timeRepositionMin, timeRepositionMax));
        }        
    }

    private void Start()
    {
        StartCoroutine(Reposition());
    }

    private void Move()
    {
        movement = Vector3.Lerp(movement, targetMovement, 0.01f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, Vector3.SignedAngle(Vector3.up, movement, Vector3.forward))), 0.05f);
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;        
    }
}
