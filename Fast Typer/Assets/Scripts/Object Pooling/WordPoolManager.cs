using System;
using System.Collections.Generic;
using UnityEngine;

public class WordPoolManager : MonoBehaviour
{
    private const int POOL_SIZE = 10;

    public static WordPoolManager Instance { get; private set; }

    public event EventHandler OnGetEnemyFromPool;


    [SerializeField] private GameObject _enemyPrefab;
    private Queue<GameObject> _enemyPool;


    //Getters - Setters
    public Queue<GameObject> EnemyPool { get => _enemyPool; }
    
    private void Awake()
    {
        #region SingletonPattern
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }

    private void Start()
    {
        _enemyPool = new Queue<GameObject>();
        for (int i = 0; i < POOL_SIZE; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.SetActive(false);
            _enemyPool.Enqueue(enemy);
        }
    }

    public GameObject GetEnemyFromPool()
    {
        if (_enemyPool.Count > 0)
        {
            GameObject _createdEnemy = _enemyPool.Dequeue();
            _createdEnemy.SetActive(true);
            OnGetEnemyFromPool?.Invoke(_createdEnemy, EventArgs.Empty);
            return _createdEnemy;
        }
        return null;
    }

    public void ReturnEnemyToPool(GameObject enemy)
    {
        _enemyPool.Enqueue(enemy);
        enemy.SetActive(false);
    }
}
