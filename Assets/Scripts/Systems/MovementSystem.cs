using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Entities.ForEach((ref Translation translation, in Movable movable) => {

            translation.Value += movable.moveVector * movable.speed * deltaTime;

        }).Schedule();
    }
}