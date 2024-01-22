using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System;

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

    public AuthManager authManager;

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        ToggleButtonStatus(false);

        UpdateStatus("Connection Status");

        authManager.userDataCallBack += HandleUserData;
        authManager.warnMessage += UpdateStatus;

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
        authManager.LoginWithExistingUser(_emailField.text, _passwordField.text);
        Debug.Log("Login");
        return;
    }

    public void OnSignUp()
    {
        authManager.SignUpWithNewUserAsync(_emailField.text, _passwordField.text);
        Debug.Log("SignUp");
    }

    public void HandleUserData(Firebase.Auth.FirebaseUser user, string operation)
    {
        Debug.Log("handle User Data");  

        StartCoroutine(WaitLoadSceneCoroutine(user));
    }

    public IEnumerator WaitLoadSceneCoroutine(FirebaseUser user)
    {
        UpdateStatus($"Welcome back {user.Email}");
        yield return new WaitForSeconds(3f);

        UpdateStatus("Loading Game Scene");
        yield return new WaitForSeconds(2f);

        Debug.Log("will active new scene");
        SceneManager.LoadScene(1);

    }

    public void UpdateStatus(string message)
    {
        Debug.Log("update message");
        _statusText.text = message;
    }

    private void OnDestroy()
    {
        authManager.userDataCallBack -= HandleUserData;
        authManager.warnMessage -= UpdateStatus;
    }
}
