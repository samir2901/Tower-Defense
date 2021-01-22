using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerStats.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerStats.health;
    }
}
