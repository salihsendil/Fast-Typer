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
        _currentScore = Mathf.Max(0, _currentScore + score);
        _scoreText.text = "Score: " + _currentScore.ToString();
    }

}
