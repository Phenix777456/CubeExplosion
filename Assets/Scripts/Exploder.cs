using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
        
    public void Explode(Vector3 HitPoint, float explosionForce)
    {
        foreach (Rigidbody rb in GetExploadableObjects(HitPoint))
            rb.AddExplosionForce(explosionForce, HitPoint, _explosionRadius);
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
