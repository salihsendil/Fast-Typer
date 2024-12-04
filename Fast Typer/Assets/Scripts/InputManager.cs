using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private TMP_InputField _inputField;

    private void Awake()
    {
        #region SingletonPattern
        if (Instance!=null)
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
        if (_inputField)
        {
            _inputField.onSubmit.AddListener(PlayerPressedEnter);
            _inputField.onSubmit.AddListener(GameManager.Instance.CompareInputWithCurrentWord);
        }
    }

    void Update()
    {

    }

    private void PlayerPressedEnter(string inputText)
    {
        if (_inputField.text != "")
        {
            Debug.Log("Kullanýcý þunu yazdý: " + inputText);
            _inputField.text = "";
            _inputField.Select();
            _inputField.ActivateInputField();
        }
    }
}
