using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private Text _timeWave;

    private float _countDown = 3f;

    private int waveIndex;

    private void Start()
    {
        waveIndex = 0;
    }

    private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }

        
        _countDown -= Time.deltaTime;

        _countDown = Mathf.Clamp(_countDown, 0, Mathf.Infinity);

        _timeWave.text = $"{_countDown:00.00}";
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab,_spawnPoint.position,_spawnPoint.rotation);
    }
}
