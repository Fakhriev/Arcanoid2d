using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class VelocityMovement : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in Velocity velocity) => {

            translation.Value += velocity.vector * deltaTime;

        }).Schedule();
    }
}