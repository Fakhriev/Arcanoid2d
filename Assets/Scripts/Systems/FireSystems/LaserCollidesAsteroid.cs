using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;

[UpdateBefore(typeof(DestroySystem))]
public class LaserCollidesAsteroid : SystemBase
{
    private HashSet<Entity> _removeSpawnEntities = new HashSet<Entity>();

    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;

        Entities.ForEach((DynamicBuffer<TriggerBuffer> triggerBuffer, Entity entity, in Laser laser) =>
        {
            for (int i = 0; i < triggerBuffer.Length; i++)
            {
                Entity hitEntity = triggerBuffer[i].entity;

                if (HasComponent<Enemy>(hitEntity) && HasComponent<Asteroid>(hitEntity) && HasComponent<SpawnFewOnDestroy>(hitEntity))
                {
                    _removeSpawnEntities.Add(hitEntity);
                }
            }

        }).WithoutBurst().Run();

        foreach (Entity entity in _removeSpawnEntities)
        {
            dstManager.RemoveComponent<SpawnFewOnDestroy>(entity);
        }
    }
}