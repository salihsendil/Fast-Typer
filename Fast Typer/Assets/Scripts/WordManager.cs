using UnityEngine;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance { get; private set; }
    private bool _isLastIndexFound;

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

    public string GetRandomWord()
    {
        int random = Random.Range(0, GetLastIndexByWordLength());
        string word = WordListImporter.Instance.WordsList[random]._word;
        return word;
    }

    int GetLastIndexByWordLength()
    {
        int lastIndex = 0;
        _isLastIndexFound = false;

        for (int index = 0; !_isLastIndexFound; index++)
        {
            if (WordListImporter.Instance.WordsList[index]._wordLength <= GameManager.Instance.LevelDifficulty)
            {
                lastIndex = index;
            }
            else
            {
                _isLastIndexFound = true;
            }
        }
        return lastIndex;
    }

}
