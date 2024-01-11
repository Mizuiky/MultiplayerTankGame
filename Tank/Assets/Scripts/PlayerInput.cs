using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    private float _horizontal;
    private float _vertical;

    private Vector2 _currentInput;

    //public Vector2 GetDirection()
    //{
    //    _horizontal = Input.GetAxis("Horizontal");
    //    _vertical = Input.GetAxis("Vertical");

    //    _currentInput = new Vector2(_horizontal, _vertical);

    //    return _currentInput;
    //}

    public Vector2 GetDirection()
    {
        
        return new Vector2(_horizontal, _vertical);
    }
}
