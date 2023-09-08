using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Controls controls;
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private Transform tank;
    [SerializeField] private float speed;
    [SerializeField] private List<WeaponScript> weaponScripts;
    //[SerializeField] private Transform borderLD;
    //[SerializeField] private Transform borderRU;


    private void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        movement = Vector3.Lerp(movement,controls.KeyAndMouse.Move.ReadValue<Vector2>(), 0.01f);
        tank.rotation = Quaternion.Lerp(tank.rotation, Quaternion.Euler(new Vector3(0,0, Vector3.SignedAngle(Vector3.up,movement, Vector3.forward))), 0.05f);
    }

    private void Shot(InputAction.CallbackContext context)
    {
        foreach (WeaponScript ws in weaponScripts)
        {
            ws.Shot(tank.rotation, transform.parent);
        }               
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
        //if (transform.position.x > borderRU.position.x) transform.position = new Vector3(borderRU.position.x, transform.position.y, transform.position.z);
        //if (transform.position.x < borderLD.position.x) transform.position = new Vector3(borderLD.position.x, transform.position.y, transform.position.z);
        //if (transform.position.y > borderRU.position.y) transform.position = new Vector3(transform.position.x, borderRU.position.y, transform.position.z);
        //if (transform.position.y < borderLD.position.y) transform.position = new Vector3(transform.position.x, borderLD.position.y, transform.position.z);
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.KeyAndMouse.Shot.performed += Shot;
        GetComponentInChildren<UpgradeTank>().upgradeEvent += ActivateCannon;
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

    private void OnDisable()
    {
        controls.Disable();
    }
}
