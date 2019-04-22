using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _wavepointIndex = 0;
    private Enemy _enemy;
    
    private void Start()
    {
        _target = Waypoints.Points[_wavepointIndex];
        
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.5f)
        {
            transform.position = _target.position;
            SetNextPoint();
        }

        _enemy.Speed = _enemy.StartSpeed;
    }
    
    private void SetNextPoint()
    {
        try
        {
            _wavepointIndex++;
            _enemy.Speed += _enemy.SpeedUp;
            _target = Waypoints.Points[_wavepointIndex];
        }
        catch (IndexOutOfRangeException ex)
        {
            PushTower();
        }
    }
    
    

    private void PushTower()
    {
        Tower.instance.Push(_enemy.Damage);
        
        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }
}
