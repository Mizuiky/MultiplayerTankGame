using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    private float _horizontal;
    private float _vertical;

    public Vector2 GetDirection()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        return new Vector2(_horizontal, _vertical);
    }
}
