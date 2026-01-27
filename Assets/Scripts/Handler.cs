using System;
using UnityEditor.Rendering;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _rayCast;
    [SerializeField] private Exploder _burstEffect;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _rayCast.RaycastHit += OnProcessObject;
    }

    private void OnDisable()
    {
        _rayCast.RaycastHit -= OnProcessObject;
    }

    private void OnProcessObject(Cube ClickedObject, Vector3 HitPoint)
    {

        if (ClickedObject == null)
            return;

        float random = UnityEngine.Random.Range(0f, 100f);

        bool isDoubled = (random < ClickedObject.ChanceToDouble);

        if (isDoubled)
        {
            _spawner.Spawn(ClickedObject, HitPoint);
            _burstEffect.Explode(HitPoint);
        }

        Destroy(ClickedObject.gameObject);
    }
}