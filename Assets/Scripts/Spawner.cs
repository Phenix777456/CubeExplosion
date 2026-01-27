using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(Cube ClickedObject, Vector3 HitPoint)
    {      
        int random = UnityEngine.Random.Range(2, 7);

        if (ClickedObject != null)
        {
            float cubeChance = ClickedObject.ChanceToDouble / 2;

            for (int i = 0; i < random; i++ )
            {
                Cube cube = Instantiate(ClickedObject, HitPoint, Quaternion.identity);
                cube.transform.localScale *= 0.5f;
                cube.SetChance(cubeChance);
            }
        }
    }
}
