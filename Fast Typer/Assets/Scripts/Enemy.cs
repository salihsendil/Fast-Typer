using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private TMP_Text _wordText;
    private Vector3 _targetPos;
    private Vector3 _newPos;
    private float _speed = 0.5f;

    //Getters - Setters
    public string WordText { get => _wordText.text; }

    void Awake()
    {
        _wordText = GetComponentInChildren<TMP_Text>();
        _targetPos = Player.Instance.transform.position;
    }

    private void OnDisable()
    {
        Debug.Log(Time.deltaTime);
    }

    private void OnEnable()
    {
        _wordText.text = WordManager.Instance.GetRandomWord();
        transform.position = EnemySpawner.Instance.GetRandomSpawnPoint();
        Quaternion.LookRotation(_targetPos);
        _speed += Time.deltaTime;
    }

    void Update()
    {
        Vector3 direction = (_targetPos - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
