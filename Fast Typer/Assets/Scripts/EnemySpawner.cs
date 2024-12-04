using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }
    private GameObject _enemy;
    private float _spawnDelay = 3f;

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

    void Start()
    {
        StartCoroutine(EnemySpawnDelay());
        //StartCoroutine(EnemyReturnDelay());
    }

    void Update()
    {

    }

    private IEnumerator EnemySpawnDelay()
    {
        yield return new WaitForSeconds(_spawnDelay);
        while (WordPoolManager.Instance.EnemyPool.Count > 0)
        {
            yield return new WaitForSeconds(_spawnDelay);
            _enemy = WordPoolManager.Instance.GetEnemyFromPool();
        }
    }

    //private IEnumerator EnemyReturnDelay()
    //{
    //    yield return new WaitForSeconds(_spawnDelay*2);
    //    WordPoolManager.Instance.ReturnEnemyToPool(_enemy);
    //}

}
