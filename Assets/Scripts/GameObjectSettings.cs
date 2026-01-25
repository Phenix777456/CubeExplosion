using System;
using UnityEngine;

public class GameObjectSettings : MonoBehaviour
{
    public bool FinalChance { get; private set; }

    private float ChanceToDouble = 100f;

    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.OnDoubled += CalculateChance;
    }

    private void OnDisable()
    {
        _spawner.OnDoubled -= CalculateChance;
    }

    private void CalculateChance()
    {
        float RandomInt = UnityEngine.Random.Range(1, 100f);
        FinalChance = RandomInt <= ChanceToDouble;
        ChanceToDouble /= 2f;
    }
}
