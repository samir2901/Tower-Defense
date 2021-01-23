using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = enemyHealth.startHealth;
        slider.value = enemyHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemyHealth.health;
    }
}
