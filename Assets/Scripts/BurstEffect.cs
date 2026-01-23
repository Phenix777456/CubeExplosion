using System.Collections.Generic;
using UnityEngine;

public class BurstEffect : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.ButtonIsPressed += Explode;
    }

    private void OnDisable()
    {
        _inputReader.ButtonIsPressed -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody ExploadedObject in GetExploadableObjects())
            ExploadedObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
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
