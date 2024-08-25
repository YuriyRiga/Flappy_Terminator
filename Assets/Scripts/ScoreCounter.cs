using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _value = 0;

    public event Action<int> OnChanged;

    public void Add()
    {
        _value++;
        OnChanged?.Invoke(_value);
    }

    public void Reset()
    {
        _value = 0;
        OnChanged?.Invoke(_value);
    }
}
