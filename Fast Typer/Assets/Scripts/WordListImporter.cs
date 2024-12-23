using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class WordListImporter : MonoBehaviour
{
    public static WordListImporter Instance { get; private set; }

    StreamReader streamReader;
    private string _wordsPath = Application.dataPath + "/Source/kelimeler.txt";
    private static List<WordData> _wordsList;

    public List<WordData> WordsList { get => _wordsList; }

    public struct WordData
    {
        public string _word;
        public int _wordLength;

        public WordData(string word, int wordLength)
        {
            _word = word;
            _wordLength = wordLength;
        }
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        _wordsList = new List<WordData>();
        try
        {
            using (StreamReader streamReader = new StreamReader(_wordsPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string word = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(word))
                    {
                        WordData _wordData = new WordData(word, word.Length);
                        WordsList.Add(_wordData);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("File could not read: " + ex.Message);
        }
    }

    //private void Start()
    //{
    //    foreach (var word in _wordsList)
    //    {
    //        Debug.Log(word._word);
    //    }
    //}

}
