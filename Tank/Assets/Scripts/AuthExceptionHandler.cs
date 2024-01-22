using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthExceptionHandler
{
    public static string GetExceptionMessage(AuthError authError)
    {
        string _msg = "";

        switch (authError)
        {
            case AuthError.EmailAlreadyInUse:
                _msg = "The email has already been registered. Please try another one.";
                break;

            case AuthError.InvalidEmail:
                _msg = "The email is invalid. Please try another one.";
                break;

            case AuthError.WrongPassword:
                _msg = "Your password is wrong. Try again";
                break;

            case AuthError.Cancelled:
                _msg = "The Operation is cancelled. Please try again.";
                break;

            case AuthError.Failure:
                _msg = "An Internal Error happened.";
                break;

            default:
                _msg = "An undefined Error happened.";
                break;
        }

        return _msg;
    }
}
