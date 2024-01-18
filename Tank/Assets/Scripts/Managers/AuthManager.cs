using System.Collections;
using UnityEngine;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase;
using System;

public class AuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;

    public delegate IEnumerator UserDataCallBack(Firebase.Auth.FirebaseUser user, string operation);
    public event UserDataCallBack userDataCallBack;

    public void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Debug.Log("auth");
    }

    public async void SignUpWithNewUser(string email, string password)
    {
        AuthResult result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);

        //melhorar isso depois porque precisa ver as excecoes

        if(result != null)
            StartCoroutine(userDataCallBack(result.User, "sign_up"));
    }
}
