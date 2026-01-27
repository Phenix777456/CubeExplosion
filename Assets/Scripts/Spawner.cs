using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    private List<Rigidbody> _burstedCubes = new();
    private List<Rigidbody> _newBurstedCubes = new();

    private float _changeScale = 0.5f;
    private int minCiuntOfCubes = 2;
    private int maxCiuntOfCubes = 7;
    private int decreeseChance = 2;

    public void Spawn(Cube ClickedObject, Vector3 HitPoint)
    {      
        int random = UnityEngine.Random.Range(minCiuntOfCubes, maxCiuntOfCubes);

        if (ClickedObject != null)
        {
            float cubeChance = ClickedObject.ChanceToDouble / decreeseChance;

            for (int i = 0; i < random; i++)
            {
                Cube cube = Instantiate(ClickedObject, HitPoint, Quaternion.identity);
                _burstedCubes.Add(cube.GetComponent<Rigidbody>());
                _colorChanger.ApplyRandomColor(cube.GetComponent<Renderer>());
                cube.transform.localScale *= _changeScale;
                cube.SetChance(cubeChance);
            }
        }
    }

    public List<Rigidbody> ReturnBurstedCubes()
    {
        _burstedCubes = _newBurstedCubes;
        _burstedCubes = new List<Rigidbody>();
        return _newBurstedCubes;
    }
}
