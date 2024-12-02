using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private TMP_InputField _inputField;

    private void Awake()
    {
        _inputField = GetComponentInChildren<TMP_InputField>();
    }

    void Start()
    {
        _inputField.Select();
        _inputField.ActivateInputField();
    }

    
    void Update()
    {

    }
}
