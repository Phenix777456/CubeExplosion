using UnityEngine;
using System;
using Unity.VisualScripting;

public class InputReader : MonoBehaviour
{
    private const KeyCode PressedButton = KeyCode.Mouse1;
    public event Action ButtonIsPressed;

    private void Update()
    {
        if (Input.GetKeyDown(PressedButton))
            ButtonIsPressed?.Invoke();
    }
}