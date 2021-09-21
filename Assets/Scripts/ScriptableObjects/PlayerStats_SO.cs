using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "New Player Stats SO", order = 51)]
public class PlayerStats_SO : ScriptableObject
{
    [Header("Movement Parametres")]
    [SerializeField] private float acceleration;
    [SerializeField] private float maximumSpeed;

    [Header("Stop Parametres")]
    [SerializeField] private float deaccelerationSpeed;
    [SerializeField] private float stopThreshold;

    [Header("Rotation Parametres")]
    [SerializeField] private float rotationSpeed;

    public float Acceleration
    {
        get
        {
            return acceleration;
        }
    }

    public float MaximumSpeed
    {
        get
        {
            return maximumSpeed;
        }
    }

    public float DeaccelerationSpeed
    {
        get
        {
            return deaccelerationSpeed;
        }
    }

    public float StopThreshold
    {
        get
        {
            return stopThreshold;
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