using System;
using UnityEngine;

public abstract class Objects : MonoBehaviour
{
    public event Action<Objects> Disable;

    public void Initialize(Vector2 position)
    {
        transform.position = position;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        Disable?.Invoke(this);
    }
}
