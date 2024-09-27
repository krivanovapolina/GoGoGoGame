using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
}
