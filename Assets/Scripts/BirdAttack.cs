using System;
using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    [SerializeField] private Transform _pointShot;
    [SerializeField] private SpawnerBulletBird _spawnerBullet;


    private void Update()
    {
        bool _mouseInput = Input.GetMouseButtonDown(0);

        if (_mouseInput)
        {
            Attack();
        }
    }

    private void Attack()
    {
        _spawnerBullet.SpawnObject(_pointShot.position, _pointShot.rotation);
    }
}
