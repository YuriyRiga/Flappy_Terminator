using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _reload;
    [SerializeField] private Transform _pointShot;

    private SpawnerBulletEnemy _spawnerBullet;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Attack());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public void Initialize(SpawnerBulletEnemy spawnerBullet)
    {
        _spawnerBullet = spawnerBullet;
    }

    private IEnumerator Attack()
    {
        var delay = new WaitForSeconds(_reload);

        while (gameObject.activeSelf)
        {
            if (_spawnerBullet != null)
            {
                _spawnerBullet.SpawnObject(_pointShot.position, _pointShot.rotation);
            }

            yield return delay;
        }
    }
}
