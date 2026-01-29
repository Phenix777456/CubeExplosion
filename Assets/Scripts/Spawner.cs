using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    private float _changeScale = 0.5f;
    private int minCiuntOfCubes = 2;
    private int maxCiuntOfCubes = 7;

    public void Spawn(Cube ClickedObject, Vector3 HitPoint)
    {      
        int random = UnityEngine.Random.Range(minCiuntOfCubes, maxCiuntOfCubes);

        if (ClickedObject != null)
        {

            for (int i = 0; i < random; i++)
            {
                Cube cube = Instantiate(ClickedObject, HitPoint, Quaternion.identity);
                _colorChanger.ApplyRandomColor(cube.GetComponent<Renderer>());
                cube.transform.localScale *= _changeScale;
                cube.DecreaceChance();
                cube.IncreaceForce();
            }
        }
    }
}
