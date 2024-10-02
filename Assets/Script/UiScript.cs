using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class UiScript : MonoBehaviour
{
    CharacterStats stats;
    
    CharAttack charAttack;
    public Slider hpBar;
    public Slider armorBar;
    public Slider exBar;

    public TMP_Text lvltext;
    public TMP_Text ammoText;
    public TMP_Text moneyText;

    public Image Slot1;
    public Image Slot2;
    public Image Slot3;

    public GunType gunType;


    void Start()
    {
        stats = FindObjectOfType<CharacterStats>();
        charAttack = FindObjectOfType<CharAttack>();
    }

    
    void Update()
    {
        InitializeStats(); 
    }

    void InitializeStats()
    {
        hpBar.value = stats.Hp;
        armorBar.value = stats.Armor;
        exBar.value = stats.Experience;
        lvltext.text = stats.Level + " LVL";
        ammoText.text = charAttack.HandleChangeGun().Ammo + "/" + charAttack.HandleChangeGun().MaxAmmo;
        moneyText.text = "$ " + stats.Money;

    }

    void Light()
    {
        if(gunType == GunType.Knife)
        {
            Color color1 = Slot2.color;
            Color color2 = Slot3.color;
            color1.a = 0.5f;
            color2.a = 0.5f;
            Slot2.color = color1;
            Slot3.color = color1;
        }
    }
}
