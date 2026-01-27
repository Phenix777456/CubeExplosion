using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    public void Explode(Vector3 HitPoint)
    {
        List<Rigidbody> exploadableObjects = GetExploadableObjects(HitPoint);

        foreach (Rigidbody ExploadedObject in exploadableObjects)
            ExploadedObject.AddExplosionForce(_explosionForce, HitPoint, _explosionRadius);
    }

    private List<Rigidbody> GetExploadableObjects(Vector3 HitPoint)
    {
        Collider[] Hits = Physics.OverlapSphere(HitPoint, _explosionRadius);

        List<Rigidbody> Cubes = new();

        foreach (Collider hit in Hits)
            if (hit.attachedRigidbody != null)
                Cubes.Add(hit.attachedRigidbody);

        return Cubes;
    }
}
