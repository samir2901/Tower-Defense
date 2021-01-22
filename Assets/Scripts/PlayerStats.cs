using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 100;
    private void Start()
    {
        money = startMoney;
    }
}
