using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Ray _ray;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 20;
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube, Vector3> RaycastHit;

    private void OnEnable()
    {
        _inputReader.ButtonIsPressed += OnRaycastFromMouse;
    }

    private void OnDisable()
    {
        _inputReader.ButtonIsPressed -= OnRaycastFromMouse;
    }

    private void OnRaycastFromMouse()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.magenta);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            GameObject objectHit = hit.collider.gameObject;

            if (objectHit.TryGetComponent(out Cube cube))
            {
                RaycastHit?.Invoke(cube, hit.point);
            }
        }
    }
}
