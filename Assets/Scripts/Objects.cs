using System;
using UnityEngine;

public abstract class Objects : MonoBehaviour
{
    public event Action<Objects> Disable;

    public void Initialize(Vector2 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        Disable?.Invoke(this);
    }
}
