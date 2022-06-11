using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

[UpdateBefore(typeof(DestroySystem))]
public class SpawnAtDestroySystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityCommandBufferSystem entityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        EntityCommandBuffer entityCommandBuffer = entityCommandBufferSystem.CreateCommandBuffer();
        EntityManager dstManager = World.EntityManager;

        Entities.ForEach((Entity entity, in NeedToDestroy needToDestroy, in SpawnOnDestroy spawnOnDestroy, in Translation translation, in Rotation rotation) =>
        {
            Entity newEntity = dstManager.Instantiate(spawnOnDestroy.entityToSpawn);
            EntityManager.SetComponentData(newEntity, translation);
            EntityManager.SetComponentData(newEntity, rotation);

        }).WithStructuralChanges().Run();

        Entities.ForEach((Entity entity, in NeedToDestroy needToDestroy, in SpawnFewOnDestroy spawnFewOnDestroy, in Translation translation, in Rotation rotation) =>
        {
            for (int i = 0; i < spawnFewOnDestroy.amount; i++)
            {
                Entity newEntity = dstManager.Instantiate(spawnFewOnDestroy.entityToSpawn);
                EntityManager.SetComponentData(newEntity, translation);
                EntityManager.SetComponentData(newEntity, rotation);
            }

        }).WithStructuralChanges().Run();
    }
}
