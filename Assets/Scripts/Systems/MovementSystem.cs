using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Entities.ForEach((ref Translation translation, in Movable movable) => {

            translation.Value += movable.velocityVector * deltaTime;

        }).Schedule();
    }
}
