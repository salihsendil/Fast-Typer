using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject _enemy;
    private float _spawnDelay = 5f;

    void Start()
    {
        StartCoroutine(EnemySpawnDelay());
    }


    void Update()
    {

    }

    private IEnumerator EnemySpawnDelay()
    {
        yield return new WaitForSeconds(_spawnDelay);
        _enemy = WordPoolManager.Instance.GetEnemyFromPool();
    }
}
