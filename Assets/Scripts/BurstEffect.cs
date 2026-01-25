using System.Collections.Generic;
using UnityEngine;

public class BurstEffect : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Handler _handler;

    private void OnEnable()
    {
        _handler.OnExplodeRequested += Explode;
    }

    private void OnDisable()
    {
        _handler.OnExplodeRequested -= Explode;
    }

    private void Explode(Vector3 HitPoint)
    {
        foreach (Rigidbody ExploadedObject in GetExploadableObjects())
            ExploadedObject.AddExplosionForce(_explosionForce, HitPoint, _explosionRadius);
    }

    private List<Rigidbody> GetExploadableObjects()
    {
        Collider[] Hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> Cubes = new();

        foreach (Collider hit in Hits)
            if (hit.attachedRigidbody != null)
                Cubes.Add(hit.attachedRigidbody);

        return Cubes;
    }

    

}
