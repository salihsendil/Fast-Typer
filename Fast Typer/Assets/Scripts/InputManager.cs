using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    void Start()
    {
        if (_inputField)
        {
            _inputField.onSubmit.AddListener(PlayerPressedEnter);
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
