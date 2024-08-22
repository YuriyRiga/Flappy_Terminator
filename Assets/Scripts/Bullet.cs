using UnityEngine;

public class Bullet : Objects
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private bool _isPlayerShooter;

    public bool IsPlayerShooter => _isPlayerShooter;
    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}