using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ChanceToDouble = 100f;

    public void SetChance(float chance)
    {
        ChanceToDouble = chance;
    }
}
