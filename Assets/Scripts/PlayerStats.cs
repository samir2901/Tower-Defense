using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{    
    public static int money;
    public static int health;
    public int startHealth = 100;
    public int startMoney = 100;

    private void Start()
    {
        money = startMoney;
        health = startHealth;
    }   
}
