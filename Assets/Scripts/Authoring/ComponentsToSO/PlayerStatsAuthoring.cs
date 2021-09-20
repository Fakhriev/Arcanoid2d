using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerStatsAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public PlayerStats_SO PlayerStats;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Movable movable = dstManager.GetComponentData<Movable>(entity);
        Rotative rotative = dstManager.GetComponentData<Rotative>(entity);

        movable.speed = PlayerStats.FlySpeed;
        rotative.rotationSpeed = PlayerStats.RotationSpeed;

        dstManager.SetComponentData(entity, movable);
        dstManager.SetComponentData(entity, rotative);
    }
}