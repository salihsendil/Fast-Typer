using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class WordInputter : MonoBehaviour
{
    StreamReader streamReader;
    private string _wordsPath = Application.dataPath + "/Source/kelimeler.txt";
    private List<string> _wordsList;

    void Start()
    {
        _wordsList = new List<string>();
        try
        {
            using (StreamReader streamReader = new StreamReader(_wordsPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string word = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(word))
                    {
                        _wordsList.Add(word);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Dosya okunurken bir hata oluþtu: " + ex.Message);
        }
    }

    void Update()
    {

    }
}
