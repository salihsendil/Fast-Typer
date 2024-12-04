using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    private TMP_InputField _inputField;
    private float _currentScore = 0;
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

    }


    void Update()
    {

    }

    public void UpdateScore(float score)
    {
        if (_currentScore >= Mathf.Abs(score))
        {
            _currentScore += score;
        }
        else
        {
            _currentScore = 0;
        }
            _scoreText.text = "Score: " + _currentScore.ToString();
    }

}
