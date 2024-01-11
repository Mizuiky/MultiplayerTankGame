using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private string _name;
    public string Name { get { return _name; } set { _name = value; } }

    private readonly IHealth _health;
    private readonly IInput _input;
    private readonly IMovement _movement;

    private Vector2 _movementInput;

    public Player(IHealth health, IMovement movement, IInput input)
    {
        _health = health;
        _movement = movement;
        _input = input;
    }

    public void Update()
    {
        _movementInput = _input.GetDirection();
        _movement.Move(_movementInput);
        _movement.Rotate();
    }
}
