using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float ChanceToDouble = 100f;
    [SerializeField] private float ForceOfExplosion = 500f;

    public void DecreaceChance()
    {
        ChanceToDouble /= 2;
    }

    public void IncreaceForce()
    {
        ForceOfExplosion *= 2;
    }

    public float ReturnChance()
    {
        return ChanceToDouble;
    }

    public float ReturnForce()
    {
        return ForceOfExplosion;
    }
}
