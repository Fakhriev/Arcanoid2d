using System;
using TMPro;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Parametres : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmpPosition;
    [SerializeField] private TextMeshProUGUI _tmpAngle;

    [SerializeField] private TextMeshProUGUI _tmpVelocity;
    
    [SerializeField] private TextMeshProUGUI _tmpLaserCount;
    [SerializeField] private TextMeshProUGUI _tmpLaserReload;

    public void UpdateAll(Translation playerTranslation, Rotation rotation, Velocity playerVelocity, CanLaserShoot playerLaser)
    {
        UpdateTranslation(playerTranslation);
        UpdateRotation(rotation);

        UpdateVelocity(playerVelocity);
        UpdateLaserCountAndReload(playerLaser);
    }

    private void UpdateTranslation(Translation translation)
    {
        _tmpPosition.text = $"Position: {translation.Value.x.ToString("0.0")}, {translation.Value.y.ToString("0.0")}";
    }

    private void UpdateRotation(Rotation ecsRotation)
    {
        Quaternion rotation = new Quaternion(ecsRotation.Value.value.x, ecsRotation.Value.value.y, ecsRotation.Value.value.z, ecsRotation.Value.value.w);
        _tmpAngle.text = $"Angle: {Convert.ToInt32(rotation.eulerAngles.z)}";
    }

    private void UpdateVelocity(Velocity velocity)
    {
        _tmpVelocity.text = $"Velocty: {math.length(velocity.vector).ToString("0.0")}";
    }

    private void UpdateLaserCountAndReload(CanLaserShoot laser)
    {
        _tmpLaserCount.text = $"Lasers: {laser.amount}";
        _tmpLaserReload.text = $"L. Reload: {laser.reload.ToString("0.0")}";
    }
}