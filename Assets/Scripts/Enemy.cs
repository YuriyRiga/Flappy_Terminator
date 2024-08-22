using UnityEngine;
public class Enemy : Objects
{
    private EnemyAttack _enemyAttack;
    
    private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
    }

    public void Initialize(SpawnerBulletEnemy spawnerBullet, Vector2 position) 
    {
        transform.position = position;
        _enemyAttack.Initialize(spawnerBullet);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet) && bullet.IsPlayerShooter == true)
        {
            Deactivate();
            _scoreCounter = FindAnyObjectByType<ScoreCounter>();
            _scoreCounter.Add();
        }
    }
}

