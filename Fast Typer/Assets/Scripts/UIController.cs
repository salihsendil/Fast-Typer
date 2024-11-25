using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private string _userInput;

    //Getter Setters
    public string UserInput { get => _userInput; }

    void Start()
    {
        if (_inputField)
        {
            _inputField.Select();
            _inputField.ActivateInputField();
        }
    }

    void Update()
    {

    }

    public void GetInputWord()
    {
        if (_inputField.text != null)
        {
            string input = _inputField.text;
            _userInput = input;
            Debug.Log(_userInput + " girildi");
            _inputField.text = "";
            _inputField.ActivateInputField();
        }
    }
}
