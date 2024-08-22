using System;
using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    [SerializeField] private Transform _pointShot;
    [SerializeField] private SpawnerBulletBird _spawnerBullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }    
    }

    private void Attack()
    {        
        _spawnerBullet.SpawnObject(_pointShot.position);
    }
}
