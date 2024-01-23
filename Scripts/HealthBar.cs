using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private CharStats _playerStats;

    private Slider _slider;

    private int _currentHealth;
    private int _maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        //_playerStats = PlayerManager.playerManager.GetComponent<PlayerStats>();
        _slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentHealth = _playerStats.health;
        _maxHealth = _playerStats._currMaxHealth;

        _slider.maxValue = _maxHealth;
        _slider.value = _currentHealth;
    }
}
