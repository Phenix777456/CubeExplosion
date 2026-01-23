using UnityEngine;
using System;
using Unity.VisualScripting;

public class InputReader : MonoBehaviour
{
    public event Action ButtonIsPressed;

    private void OnMouseDown()
    {
        ButtonIsPressed?.Invoke();
    }
}