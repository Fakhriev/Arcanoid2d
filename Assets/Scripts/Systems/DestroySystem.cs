using Unity.Entities;
using Unity.Jobs;

[UpdateAfter(typeof(SpawnAtDestroySystem))]
public class DestroySystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityCommandBufferSystem entityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        EntityCommandBuffer entityCommandBuffer = entityCommandBufferSystem.CreateCommandBuffer();

        Entities.ForEach((Entity entity, in NeedToDestroy needToDestroy) =>
        {
            entityCommandBuffer.DestroyEntity(entity);

        }).Schedule();

        entityCommandBufferSystem.AddJobHandleForProducer(this.Dependency);
    }
}