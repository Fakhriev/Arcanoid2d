using Unity.Entities;
using Unity.Jobs;

public class DestroySystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityCommandBufferSystem entityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        EntityCommandBuffer entityCommandBuffer = entityCommandBufferSystem.CreateCommandBuffer();

        Entities
        .WithNone<SpawnOnDestroy>()
        .WithNone<SpawnFewOnDestroy>()
        .ForEach((Entity entity, in NeedToDestroy needToDestroy) =>
        {
            entityCommandBuffer.DestroyEntity(entity);

        }).Schedule();

        entityCommandBufferSystem.AddJobHandleForProducer(this.Dependency);
    }
}