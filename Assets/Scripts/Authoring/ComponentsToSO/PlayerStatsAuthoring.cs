using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerStatsAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public PlayerStats_SO PlayerStats;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Velocity velocity = dstManager.GetComponentData<Velocity>(entity);
        Rotative rotative = dstManager.GetComponentData<Rotative>(entity);

        VelocityAcceleration velocityAcceleration = dstManager.GetComponentData<VelocityAcceleration>(entity);
        VelocityDeacceleration velocityDeacceleration = dstManager.GetComponentData<VelocityDeacceleration>(entity);

        velocity.maximum = PlayerStats.MaximumSpeed;
        rotative.rotationSpeed = PlayerStats.RotationSpeed;

        velocityAcceleration.speed = PlayerStats.Acceleration;
        velocityDeacceleration.speed = PlayerStats.DeaccelerationSpeed;
        velocityDeacceleration.stopThreshold = PlayerStats.StopThreshold;

        dstManager.SetComponentData(entity, velocity);
        dstManager.SetComponentData(entity, rotative);

        dstManager.SetComponentData(entity, velocityAcceleration);
        dstManager.SetComponentData(entity, velocityDeacceleration);
    }
}