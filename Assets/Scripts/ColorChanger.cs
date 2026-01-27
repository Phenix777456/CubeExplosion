using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private List<Color> _colors = new()
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan,
        Color.magenta,
        Color.white,
        Color.black,
        Color.gray,
    };

    private int _minIndex = 0;

    public Color GetRandomColor()
    {
        int randomIndex = Random.Range(_minIndex, _colors.Count);
        return _colors[randomIndex];
    }

    public void SetColor(Renderer renderer, Color newColor)
    {
        renderer.material.color = newColor;
    }

    public void ApplyRandomColor(Renderer renderer)
    {
        SetColor(renderer, GetRandomColor());
    }
}