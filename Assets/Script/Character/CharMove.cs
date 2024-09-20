using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 7f;

    [Header("References")]
    [SerializeField] GameObject bulletPref;

    CharacterController controller;


    public Vector2 moveDirection { get; set; }
    public Vector3 mouseDirection;

    public float moveX { get; set; }
    public float moveY { get; set; }

    public bool canShoot = true;
    
    [Header("Melee Attack")]
    [SerializeField] Transform meleeAttackPoint;
    [SerializeField] float meleeAttackRange = 1f;

    public GunType gunType = GunType.Pistol;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovementInput();
        HandleChangeGun();
    }

    void FixedUpdate()
    {
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public Vector3 GetShootingDirection()
    {

        mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection.z = 0f;
        return (mouseDirection - transform.position).normalized;


    }
    void HandleMovementInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    public void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bulletPref, transform.position + GetShootingDirection(), Quaternion.identity);
            canShoot = false;
        }
    }


    void HandleChangeGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            gunType = GunType.Pistol;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunType = GunType.Knife;
        }
        Debug.Log(gunType);
    }

    public void MeleeAttack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(meleeAttackPoint.position, meleeAttackRange);
        if (enemy != null)
        {
            Debug.Log(enemy.name);
        }
        else
        {
            Debug.Log("2");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(meleeAttackPoint.position, meleeAttackRange);
    }
}