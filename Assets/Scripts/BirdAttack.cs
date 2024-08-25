using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    [SerializeField] private Transform _pointShot;
    [SerializeField] private SpawnerBulletBird _spawnerBullet;

    private int _mouseButtonAttack = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonAttack))
        {
            Attack();
        }
    }

    private void Attack()
    {
        _spawnerBullet.SpawnObject(_pointShot.position, _pointShot.rotation);
    }
}
