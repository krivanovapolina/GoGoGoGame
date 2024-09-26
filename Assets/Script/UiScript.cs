using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiScript : MonoBehaviour
{
    CharacterStats stats;
    public Slider hpBar;
    public Slider armorBar;
    public Slider exBar;

    public TMP_Text lvltext;
    public TMP_Text ammoText;
    public TMP_Text moneyText;
    
    void Start()
    {
        stats = FindObjectOfType<CharacterStats>();
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
        lvltext.text = stats.Level.ToString();
        ammoText.text = stats.Ammo + "/" + stats.MaxAmmo;
        moneyText.text = stats.Money.ToString();
    }
}
