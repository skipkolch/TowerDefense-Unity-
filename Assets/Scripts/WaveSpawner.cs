using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;
    
    [SerializeField] private Wave[] _waves;    
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
        if (EnemiesAlive > 0)
            return;
        
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
            return;
        }

        
        _countDown -= Time.deltaTime;

        _countDown = Mathf.Clamp(_countDown, 0, Mathf.Infinity);

        _timeWave.text = $"{_countDown:00.00}";
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        var wave = _waves[waveIndex];
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveIndex++;

        if (waveIndex == _waves.Length)
        {
            Debug.Log("Level complite!");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,_spawnPoint.position,_spawnPoint.rotation);
        EnemiesAlive++;
    }
}
