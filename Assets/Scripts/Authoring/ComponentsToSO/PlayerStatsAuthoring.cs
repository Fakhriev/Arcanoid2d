using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerStatsAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public PlayerStats_SO PlayerStats;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        if(dstManager.HasComponent<Velocity>(entity))
        {
            Velocity velocity = dstManager.GetComponentData<Velocity>(entity);
            velocity.maximum = PlayerStats.MaximumSpeed;
            dstManager.SetComponentData(entity, velocity);
        }

        if (dstManager.HasComponent<Rotative>(entity))
        {
            Rotative rotative = dstManager.GetComponentData<Rotative>(entity);
            rotative.rotationSpeed = PlayerStats.RotationSpeed;
            dstManager.SetComponentData(entity, rotative);
        }

        if (dstManager.HasComponent<VelocityAcceleration>(entity))
        {
            VelocityAcceleration velocityAcceleration = dstManager.GetComponentData<VelocityAcceleration>(entity);
            velocityAcceleration.speed = PlayerStats.Acceleration;
            dstManager.SetComponentData(entity, velocityAcceleration);
        }

        if (dstManager.HasComponent<VelocityDeacceleration>(entity))
        {
            VelocityDeacceleration velocityDeacceleration = dstManager.GetComponentData<VelocityDeacceleration>(entity);
            velocityDeacceleration.speed = PlayerStats.DeaccelerationSpeed;
            velocityDeacceleration.stopThreshold = PlayerStats.StopThreshold;
            dstManager.SetComponentData(entity, velocityDeacceleration);
        }

        if (dstManager.HasComponent<InertiaResistance>(entity))
        {
            InertiaResistance inertiaResistance = dstManager.GetComponentData<InertiaResistance>(entity);
            inertiaResistance.maximum = PlayerStats.MaximumInertiaResistance;
            dstManager.SetComponentData(entity, inertiaResistance);
        }
    }
}