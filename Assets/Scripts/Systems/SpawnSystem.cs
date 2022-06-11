using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class SpawnSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Spawner spawner, in Translation translation, in Rotation rotation) => {

            if(spawner.timeToSpawn > 0)
            {
                spawner.timeToSpawn -= deltaTime;
            }
            else
            {
                Entity newEntity = dstManager.Instantiate(spawner.entityToSpawn);
                dstManager.SetComponentData(newEntity, translation);
                dstManager.SetComponentData(newEntity, rotation);

                spawner.timeToSpawn = spawner.spawnInterval;
            }

        }).WithStructuralChanges().Run();
    }
}