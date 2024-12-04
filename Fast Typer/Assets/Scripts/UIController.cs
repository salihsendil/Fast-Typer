using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    private TMP_InputField _inputField;
    private int _currentScore = 0;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;


    private void Awake()
    {
        #region SingletonPattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        #endregion

        _inputField = GetComponentInChildren<TMP_InputField>();
    }

    void Start()
    {
        _inputField.Select();
        _inputField.ActivateInputField();
        UpdateScore(_currentScore);
        _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");

    }


    void Update()
    {

    }

    public void UpdateScore(int score)
    {
        _currentScore = Mathf.Max(0, _currentScore + score);
        _scoreText.text = "Score: " + _currentScore.ToString();
        if (_currentScore >= PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", _currentScore);
            _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");
        }
    }

}
