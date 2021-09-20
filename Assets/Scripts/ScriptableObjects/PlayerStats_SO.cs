using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "New Player Stats SO", order = 51)]
public class PlayerStats_SO : ScriptableObject
{
    [Header("Movement Stats")]
    [SerializeField] private float flySpeed;
    [SerializeField] private float rotationSpeed;

    public float FlySpeed
    {
        get
        {
            return flySpeed;
        }
    }

    public float RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }
    }
}