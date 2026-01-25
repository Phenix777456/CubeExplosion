using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Handler _handler;
    [SerializeField] private GameObjectSettings _settings;

    public event Action OnDoubled; 

    private void OnEnable()
    {
        _handler.OnSpawnRequested += Spawn;
    }

    private void OnDisable()
    {
        _handler.OnSpawnRequested -= Spawn;
    }

    private void Spawn(GameObject ClickedObject, Vector3 HitPoint)
    {      
        ClickedObject.transform.localScale *= 0.5f;

        OnDoubled?.Invoke();

        bool ChanceToDooble = _settings.FinalChance;

        if (ClickedObject != null && ChanceToDooble == true)
        {
            Instantiate(ClickedObject, HitPoint, Quaternion.identity);
            Instantiate(ClickedObject, HitPoint, Quaternion.identity);    
        }

        Destroy(ClickedObject);
    }
}
