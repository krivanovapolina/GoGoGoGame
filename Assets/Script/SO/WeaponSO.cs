using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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

    private int initialAmmo;
    private int initialMaxAmmo;
    private int initialLimitMaxAmmo;
    private int initialMagazine;
    private int initialDamag;
    private float initialAttackSpeed;
    private float initialReloadTime;

    void SaveInitialValues()
    {
        initialAmmo = Ammo;
        initialMaxAmmo = MaxAmmo;
        initialLimitMaxAmmo = LimitMaxAmmo;
        initialMagazine = Magazine;
        initialDamag = Damag;
        initialAttackSpeed = AttackSpeed;
        initialReloadTime = ReloadTime;
    }

    public void ResetValues()
    {
        Ammo = initialAmmo;
        MaxAmmo = initialMaxAmmo;
        LimitMaxAmmo = initialLimitMaxAmmo;
        Magazine = initialMagazine;
        Damag = initialDamag;
        AttackSpeed = initialAttackSpeed;
        ReloadTime = initialReloadTime;
    }

    private void OnEnable()
    {
        SaveInitialValues();
    }
}