using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$"+PlayerStats.money.ToString();
    }
    
    void Update()
    {
        moneyText.text = "$" + PlayerStats.money.ToString();
    }
}
