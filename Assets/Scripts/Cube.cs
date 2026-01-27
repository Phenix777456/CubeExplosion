using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ChanceToDouble { get; private set; } = 100f;

    public void SetChance(float chance)
    {
        ChanceToDouble = chance;
    }
}
