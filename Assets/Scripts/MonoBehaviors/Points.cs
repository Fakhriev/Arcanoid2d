using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmpPoints;

    private int _value;

    public void Add(int value)
    {
        _value += value;
        _tmpPoints.text = $"Points: {_value}";
    }
}