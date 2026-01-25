using System;
using UnityEditor.Rendering;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private RayCast _rayCast;
    [SerializeField] private BurstEffect _burstEffect;
    [SerializeField] private Spawner _spawner;

    public event Action<GameObject, Vector3> OnSpawnRequested; 
    public event Action<Vector3>  OnExplodeRequested;

    private void OnEnable()
    {
        _rayCast.OnRaycastHit += ProcessObject;
    }

    private void OnDisable()
    {
        _rayCast.OnRaycastHit -= ProcessObject;
    }

    private void ProcessObject(GameObject ClickedObject, Vector3 HitPoint)
    {
        if (ClickedObject.GetComponent<GameObjectSettings>() == null) 
            return;  

        OnSpawnRequested?.Invoke(ClickedObject, HitPoint);
        OnExplodeRequested?.Invoke(HitPoint);
    }
}