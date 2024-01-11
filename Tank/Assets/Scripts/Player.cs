using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private IHealth _health;
    private IInput _playerInput;

    private IMovement _movement;
    private Vector2 _movementInput;

    private string _name;
    public string Name { get { return _name; } set { _name = value; } }

    public void Start()
    {
        Init();    
    }

    public void Init()
    {
        _health = GetComponent<IHealth>();
        _movement = GetComponent<IMovement>();
        _playerInput = GetComponent<IInput>();
    }

    public void Update()
    {
        _movementInput = _playerInput.GetDirection();

        if(_movementInput != Vector2.zero)
            _movement.Move(_movementInput);
            
        _movement.Rotate();
    }
}
