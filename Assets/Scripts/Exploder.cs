using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
        
    public void Explode(Vector3 HitPoint, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb != null)
                rb.AddExplosionForce(_explosionForce, HitPoint, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExploadableObjects(Vector3 HitPoint)
    {
        Collider[] hits = Physics.OverlapSphere(HitPoint, _explosionRadius);
        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
