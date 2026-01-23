using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GameObjectSettings _gameObject;
    //[SerializeField] private GameObjectSettings settings;
    public float _chanceOfDouble => _gameObject.ChanceOfDouble;

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
        float Randomiser = Random.Range(0,100);

        if (_gameObject != null && _chanceOfDouble >= Randomiser)
        {
            Instantiate(_gameObject, transform.position, Quaternion.identity);
            Instantiate(_gameObject, transform.position, Quaternion.identity);
            
        }

        Destroy(gameObject);
    }
}
