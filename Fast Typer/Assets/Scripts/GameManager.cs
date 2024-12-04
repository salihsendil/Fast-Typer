using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    private int _levelDifficulty = 2;
    private int _wordScoreValue = 10;
    private bool _anyMatchedWord;

    private int _currentEnemyCount;
    private Dictionary<GameObject, string> _currentWordDictionary;

    //Getters - Setters
    public int LevelDifficulty { get => _levelDifficulty; }

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
        WordPoolManager.Instance.OnGetEnemyFromPool += UpdateCurrentEnemyCount;
        _currentWordDictionary = new Dictionary<GameObject, string>();
    }

    void Update()
    {
    }

    private void UpdateCurrentEnemyCount(object sender, EventArgs e)
    {
        GameObject _enemy = sender as GameObject;
        string _word = _enemy.GetComponentInChildren<TMP_Text>().text;
        _currentWordDictionary.Add(_enemy, _word);
        _currentEnemyCount++;
    }

    public void CompareInputWithCurrentWord(string inputText)
    {
        foreach (var pair in _currentWordDictionary)
        {
            if (pair.Value.Equals(inputText))
            {
                _currentWordDictionary.Remove(pair.Key);
                _currentEnemyCount--;
                WordPoolManager.Instance.ReturnEnemyToPool(pair.Key);
                AddScore(pair.Value.Length * _wordScoreValue);
                _anyMatchedWord = true;
                break;
            }
        }

        if (!_anyMatchedWord)
        {
            AddScore(inputText.Length * _wordScoreValue * -0.5f);

            //add red screen to player feedback

        }
        _anyMatchedWord = false;
    }

    void AddScore(float score)
    {
        UIController.Instance.UpdateScore(score);
    }

}
