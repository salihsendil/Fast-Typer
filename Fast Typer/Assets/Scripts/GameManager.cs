using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    private int _difficultLevel = 2;

    private int _currentEnemyCount;
    private List<string> _currentWordList;

    //Getters - Setters
    public int DifficultLevel { get => _difficultLevel; }

    private void Awake()
    {
        #region Singleton Pattern
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion
    }


    void Start()
    {
        WordPoolManager.Instance.OnGetEnemyFromPool += GetCurrentEnemyCount;
        WordPoolManager.Instance.OnReturnEnemyToPool += EnemyDestroyed;
        _currentWordList = new List<string>();
    }

    void Update()
    {
        if (_currentWordList.Count > 0)
        {
            Debug.Log("word list index 0: " + _currentWordList[0]);
        }
        else
        {
            Debug.Log("empty list");
        }
    }

    private void GetCurrentEnemyCount(object sender, EventArgs e)
    {
        _currentEnemyCount++;
        GameObject _enemy = sender as GameObject;
        string _word = _enemy.GetComponentInChildren<TMP_Text>().text;
        _currentWordList.Add(_word);
    }

    private void EnemyDestroyed(object sender, EventArgs e)
    {
        GameObject _enemy = sender as GameObject;
        string _word = _enemy.GetComponentInChildren<TMP_Text>().text;
        for (int i = 0; i < _currentWordList.Count; i++)
        {
            if (_currentWordList[i].Equals(_word))
            {
                _currentWordList.Remove(_word);
                _currentEnemyCount++;
            }
        }
    }

}
