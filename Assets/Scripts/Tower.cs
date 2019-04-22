using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [HideInInspector] public static Tower instance;    
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _healthCanvas; 
    private float _startHealth;
    private bool _wasFirstPush;

    private void Start()
    {
        instance = this;
        _wasFirstPush = false;
        _startHealth = PlayerStats.Lives;
    }
    
    
    public void Push(float damageEnemy)
    {
        if (!_wasFirstPush)
        {
            _wasFirstPush = true;
            _healthCanvas.SetActive(true);
        }
        
        PlayerStats.Lives -= damageEnemy;
        Debug.Log( String.Format("{0} {1}", PlayerStats.Lives, _startHealth).ToString() );
        _healthBar.fillAmount = PlayerStats.Lives / _startHealth;
    }
}
