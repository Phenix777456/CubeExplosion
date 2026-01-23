using System;
using UnityEngine;

public class GameObjectSettings : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

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
    }
}
