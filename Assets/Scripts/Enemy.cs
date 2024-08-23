using UnityEngine;

[RequireComponent(typeof(EnemyAttack))]
public class Enemy : Objects
{
    private EnemyAttack _enemyAttack;
    
    private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
    }

    public void Initialize(SpawnerBulletEnemy spawnerBullet, ScoreCounter scoreCounter, Vector2 position) 
    {
        transform.position = position;
        _scoreCounter = scoreCounter;
        _enemyAttack.Initialize(spawnerBullet);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet) && bullet.IsPlayerShooter == true)
        {
            Deactivate();
            _scoreCounter.Add();
        }
    }
}

