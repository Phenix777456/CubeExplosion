using System;
using UnityEngine;

public class GameObjectSettings : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private float _chanceOfDouble = 100;

    public float ChanceOfDouble => _chanceOfDouble;

    private void OnEnable()
    {
        _inputReader.ButtonIsPressed += ChengeSize;
    }

    private void OnDisable()
    {
        _inputReader.ButtonIsPressed -= ChengeSize;
    }

    private void ChengeSize()
    {
        transform.localScale *= 0.5f;
        _chanceOfDouble /= 2;
    }
}
