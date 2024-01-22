using System.Collections;
using UnityEngine;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase;
using System;
using UnityEngine.Events;

public class AuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;

    public delegate void UserDataCallBack(Firebase.Auth.FirebaseUser user, string operation);
    public event UserDataCallBack userDataCallBack;

    public Action<string> warnMessage;

    string _errorMsg;

    AuthError _authError;

    public void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Debug.Log("auth");
    }

    public async void SignUpWithNewUserAsync(string email, string password)
    {
        Debug.Log("Create Account");

        try
        {
            AuthResult result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);

            Debug.Log("Result");

            if (result != null)
            {
                Debug.Log("Create Account Sucessfull");
                userDataCallBack?.Invoke(result.User, "_signup");
            }
            else
                Debug.Log("Create Account Cancelled");            
        }
        catch (FirebaseException e)
        {
            Debug.Log("Operation has found an error");

            FirebaseException fireBaseEx = e.GetBaseException() as FirebaseException;

            if (fireBaseEx != null)
            {
                AuthError authError = (Firebase.Auth.AuthError)fireBaseEx.ErrorCode;

                _errorMsg = AuthExceptionHandler.GetExceptionMessage(authError);

                Debug.Log($"error: {_errorMsg}");

                warnMessage?.Invoke(_errorMsg);
            }
        }
    }

    public async void LoginWithExistingUser(string email, string password)
    {
        try
        {
            AuthResult result = await auth.SignInWithEmailAndPasswordAsync(email, password);

            Debug.Log("Result");

            if (result != null)
            {
                Debug.Log("Login Account Sucessfull");
                userDataCallBack?.Invoke(result.User, "_login");
            }
        }
        catch(FirebaseException e)
        {

        }

        //melhorar isso depois porque precisa ver as excecoes

        if (result != null)
            userDataCallBack?.Invoke(result.User, "login");
    }
}
