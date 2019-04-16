using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _intensityLight;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedUp = 2;
    [SerializeField] private int _health = 100;
    [SerializeField] private int _addMoney = 50;
    [SerializeField] private GameObject _deathEffect;
    
    private Light _light;
    private Transform _target;
    private int _wavepointIndex = 0;

    
    private void Awake()
    {
        _light = GetComponent<Light>();
        _light.DOIntensity(_intensityLight, 2f);
    }

    private void Start()
    {
        _target = Waypoints.Points[_wavepointIndex];
    }

    // Update is called once per frame
    private void Update()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.5f)
        {
            transform.position = _target.position;
            SetNextPoint();
        }
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 0)
            EmenyDie();
    }

    private void EmenyDie()
    {
        var effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        
        PlayerStats.Money += _addMoney;
        Destroy(gameObject);
    }

    private void SetNextPoint()
    {
        try
        {
            _wavepointIndex++;
            _speed += _speedUp;
            _target = Waypoints.Points[_wavepointIndex];
        }
        catch (IndexOutOfRangeException ex)
        {
            PushTower();
        }
    }

    private void PushTower()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
