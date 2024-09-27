using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "Weapons")]
public class WeaponSO : ScriptableObject
{
    public int Ammo;
    public int MaxAmmo;
    public int LimitMaxAmmo;
    public int Magazine;
    public int Damag;
    public float AttackSpeed;
    public float ReloadTime;
    public GunType GunType;
    public GameObject ProjectilePrefab;
}
