using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _rayCast;
    [SerializeField] private Exploder _burstEffect;
    [SerializeField] private Spawner _spawner;

    private int _maxRandomInt = 100;
    private int _minRandomInt = 0;
    
    private void OnEnable()
    {
        _rayCast.RaycastHit += OnProcessObject;
    }

    private void OnDisable()
    {
        _rayCast.RaycastHit -= OnProcessObject;
    }

    private void OnProcessObject(Cube clickedObject, Vector3 hitPoint)
    {
        if (clickedObject == null)
            return;

        float random = UnityEngine.Random.Range(_minRandomInt, _maxRandomInt);

        bool isDoubled = (random < clickedObject.ReturnChance());

        if (isDoubled)
        {
            _spawner.Spawn(clickedObject, hitPoint);
            _burstEffect.Explode(hitPoint, clickedObject.ReturnForce()  );
        }

        Destroy(clickedObject.gameObject);
    }
}