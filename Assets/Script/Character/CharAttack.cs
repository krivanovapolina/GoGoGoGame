using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttack : MonoBehaviour
{

    [Header("Melee Attack")]
    [SerializeField] Transform meleeAttackPoint;
    [SerializeField] float meleeAttackRange = 1f;

    [Header("References")]
    [SerializeField] GameObject bulletPref;

    public bool canShoot = true;

    public GunType gunType = GunType.Pistol;

    CharacterMove move;

    void Start()
    {
        move = GetComponent<CharacterMove>();
    }

    void Update()
    {
        HandleChangeGun();
    }

    public void Bullet()
    {
        Debug.Log("asdsad");
        if (canShoot)
        {
            Instantiate(bulletPref, transform.position + move.GetShootingDirection(), Quaternion.identity);
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
            Debug.Log(enemy.name);
        else
            Debug.Log("YA UDARIL");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(meleeAttackPoint.position, meleeAttackRange);
    }

}

