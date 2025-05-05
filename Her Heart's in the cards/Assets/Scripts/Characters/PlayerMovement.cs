using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    [SerializeField] bool _isMoving;
    [SerializeField] float _speed = 5f;
    [SerializeField] Vector3 _moveDirection;
    public void Move(bool isMoving, Vector2 direction)
    {
        _isMoving = isMoving;
        _moveDirection = direction;
    }

    void Update()
    {
        if (_isMoving) transform.position += _moveDirection * Time.deltaTime * _speed;
    }
}
