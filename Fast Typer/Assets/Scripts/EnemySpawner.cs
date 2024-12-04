using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }
    private GameObject _enemy;
    private float _spawnDelay = 2f;
    private Vector2 _screenTopLeft;
    private Vector2 _screenTopRight;
    private Vector3 _randomPos;


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
        _screenTopLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        _screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

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

    public Vector3 GetRandomSpawnPoint()
    {
        _randomPos = new Vector3(Random.Range(_screenTopLeft.x, _screenTopRight.x), transform.position.y, 0);
        return _randomPos;
    }

    //private IEnumerator EnemyReturnDelay()
    //{
    //    yield return new WaitForSeconds(_spawnDelay*2);
    //    WordPoolManager.Instance.ReturnEnemyToPool(_enemy);
    //}

}
