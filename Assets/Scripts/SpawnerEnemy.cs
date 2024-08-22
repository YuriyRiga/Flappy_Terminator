using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private SpawnerBulletEnemy _bulletSpawner;

    private void OnEnable()
    {
        StartCoroutine(SpawnCouldown());
    }

    protected override void InitializeObject(Enemy obj)
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        SpawnPoint spawnPoint = _spawnPoints[randomIndex];

        obj.Initialize(_bulletSpawner, spawnPoint.transform.position);
        base.InitializeObject(obj);
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
