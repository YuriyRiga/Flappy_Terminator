using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private SpawnerBulletEnemy _bulletSpawner;

    private void OnEnable()
    {
        StartCoroutine(SpawnCouldown());
    }

    protected override void InitializeObject(Enemy enemy)
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        SpawnPoint spawnPoint = _spawnPoints[randomIndex];

        enemy.Initialize(_bulletSpawner, _scoreCounter, spawnPoint.transform.position);
        base.InitializeObject(enemy);
    }

    private IEnumerator SpawnCouldown()
    {
        var delay = new WaitForSeconds(_repeatRate);

        while (gameObject.activeSelf)
        {
            yield return delay;
            Pool.Get();
        }
    }
}
