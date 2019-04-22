using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _intensityLight;
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private float _speedUp = 2;
    [SerializeField] private float _startHealth = 100;
    [SerializeField] private int _addMoney = 50;
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _damage;
    
    private Light _light;  
    private float _currentHealth;
    private float _speed;
        
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float SpeedUp => _speedUp;
    
    public float StartSpeed => _startSpeed;

    public float Damage => _damage;
    
    private void Awake()
    {
        _light = GetComponent<Light>();
        _light.DOIntensity(_intensityLight, 2f);
        _currentHealth = _startHealth;
        _speed = _startSpeed;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        _healthBar.fillAmount = _currentHealth / _startHealth;

        if (_currentHealth <= 0)
            EmenyDie();
    }

    private void EmenyDie()
    {
        var effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        
        WaveSpawner.EnemiesAlive--;
        
        PlayerStats.Money += _addMoney;
        Destroy(gameObject);
    }


    public void Slow(float percent)
    {
        _speed = _startSpeed * (1f - percent);
    }
   
}
