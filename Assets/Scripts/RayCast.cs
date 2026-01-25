using System;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Ray _ray;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 20;
    [SerializeField] private InputReader _inputReader;

    public event Action<GameObject, Vector3> OnRaycastHit;

    private void OnEnable()
    {
        _inputReader.ButtonIsPressed += GetObject;
    }

    private void OnDisable()
    {
        _inputReader.ButtonIsPressed -= GetObject;
    }


    private void GetObject()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.magenta);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            GameObject objectHit = hit.collider.gameObject;
            OnRaycastHit?.Invoke(objectHit, hit.point);
        }
    }
}
