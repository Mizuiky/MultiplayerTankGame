using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{
    [SerializeField]
    private float speed;

    private Rigidbody2D _rigidbody;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 input)
    {
        _rigidbody.AddForce(input * speed);
    }

    public void Rotate()
    {

    }
}
