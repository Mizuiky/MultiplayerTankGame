using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Text;

public class FormManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _emailField;
    [SerializeField]
    private TMP_InputField _passwordField;
    [SerializeField]
    private TextMeshProUGUI _statusText;

    [SerializeField]
    private Button _signUpButton;
    [SerializeField]
    private Button _loginButton;

    private string _connectionStatus;

    private string _regexPattern;

    //public AuthManager authManager;

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        ToggleButtonStatus(false);

        _regexPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
    }

    public void ValidateEmail()
    {
        string email = _emailField.text;

        if (email != "" && Regex.IsMatch(email, _regexPattern))
            ToggleButtonStatus(true);
        else
            ToggleButtonStatus(false);           
    }

    public void ToggleButtonStatus(bool status)
    {
        _signUpButton.interactable = status;
        _loginButton.interactable = status;
    }

    public void OnLogin()
    {
        Debug.Log("Login");
    }

    public void OnSignUp()
    {
        Debug.Log("SignUp");
    }

    private void UpdateStatus(string message)
    {
        _statusText.text = message;
    }
}