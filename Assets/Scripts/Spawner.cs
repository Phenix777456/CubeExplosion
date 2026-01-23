using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GameObjectSettings _gameObject;

    private void OnEnable()
    {
        _inputReader.ButtonIsPressed += Spawn;
    }

    private void OnDisable()
    {
        _inputReader.ButtonIsPressed -= Spawn;
    }

    private void Spawn()
    {
        if (_gameObject != null)
        {
            Instantiate(_gameObject, transform.position, Quaternion.identity);
            Instantiate(_gameObject, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
