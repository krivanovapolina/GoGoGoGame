using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
    CharacterStats stats;
    public List<WeaponSO> weapons;

    void Start()
    {
        move = GetComponent<CharacterMove>();
        stats = GetComponent<CharacterStats>();
        
    }

    void Update()
    {
        HandleChangeGun();
    }

    private void OnDestroy()
    {
        weapons.ForEach(weapons => weapons.ResetValues());
    }

    public void Bullet()
    {
        Debug.Log("vistrel");
        if (canShoot)
        {
            Instantiate(HandleChangeGun().ProjectilePrefab, transform.position + move.GetShootingDirection(), Quaternion.identity);
            canShoot = false;
            HandleChangeGun().Ammo -= 1;
        }
    }


    public WeaponSO HandleChangeGun()
    {
        WeaponSO weapon1 = null;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            gunType = GunType.Pistol;

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunType = GunType.Knife;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunType = GunType.Crossbow;

        }
        foreach (var weapon in weapons)
        {
            if (weapon.GunType == gunType)
            {
                weapon1 = weapon;
            }
        }
        Debug.Log(gunType);
        return weapon1;
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

