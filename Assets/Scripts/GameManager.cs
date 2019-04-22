using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [SerializeField] private string _enemyTag = "Enemy";

    [SerializeField] private GameObject _gameOverUI;

    [HideInInspector] public GameObject[] GetEnemiesOnMap { get; private set; }
    
    public static bool GameIsOver;

    private void Awake()
    {
        instance = this;
        GameIsOver = false;
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
        if (Input.GetKeyDown("e"))
            EndGame();
        
        
        if(GameIsOver)
            return;
        
        if (PlayerStats.Lives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        GameIsOver = true;
        Debug.Log("Game Over");
        
        _gameOverUI.SetActive(true);
    }
}
