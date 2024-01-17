using System.Collections;
using UnityEngine;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase;

public class AuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;

    public delegate IEnumerator AuthCallBack(Task<Firebase.Auth.AuthResult> task, string operation);
    public event AuthCallBack authCallBack;

    public void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Debug.Log("auth");
    }

    public void SignUpWithNewUser(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if(task.Result != null)
            {
                Debug.Log("Before StartCoroutine");
                StartCoroutine(authCallBack(task, "sign_up"));
                Debug.Log("After StartCoroutine");
            }      
        });
    }   
}
