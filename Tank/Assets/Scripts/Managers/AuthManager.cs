using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class AuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;

    public void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void SignUpWithNewUser(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {

            if(task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Sorry there was an error creating your account, ERROR: " + task.Exception);
                return;
            }
            else if(task.IsCompleted)
            {
                Firebase.Auth.AuthResult newUser = task.Result;
                Debug.LogFormat("Welcome to Tanks Multiplayer {0}", newUser.User.Email);
            }
        });
    }
}
