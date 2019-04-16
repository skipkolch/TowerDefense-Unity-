using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [SerializeField] private string _enemyTag = "Enemy";

    [HideInInspector] public GameObject[] GetEnemiesOnMap { get; private set; }

    private bool _gameEnded;
    
    private void Awake()
    {
        instance = this;
        _gameEnded = false;
    }
    
    private void Start()
    {
        InvokeRepeating(nameof(SearchTarget), 0f, 0.5f);
    }

    private void SearchTarget()
    {
        GetEnemiesOnMap = GameObject.FindGameObjectsWithTag(_enemyTag);
    }

    private void Update()
    {
        if(_gameEnded)
            return;
        
        if (PlayerStats.Lives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        _gameEnded = true;
        Debug.Log("Game Over");
    }
}
