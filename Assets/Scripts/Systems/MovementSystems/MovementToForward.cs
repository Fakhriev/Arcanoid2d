using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MovementToForward : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in Rotation rotation, in MovableToForward movableToForward) => 
        {
            translation.Value += math.mul( rotation.Value, new float3(0, movableToForward.speed, 0) ) * deltaTime;

        }).Schedule();
    }
}