using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;

public class LaserCollidesEnemy : SystemBase
{
    private HashSet<Entity> _destroyEntities = new HashSet<Entity>();

    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;
        _destroyEntities.Clear();

        Entities.ForEach((DynamicBuffer<TriggerBuffer> triggerBuffer, Entity entity, in Laser laser) =>
        {
            for (int i = 0; i < triggerBuffer.Length; i++)
            {
                Entity hitEntity = triggerBuffer[i].entity;

                if (HasComponent<Enemy>(hitEntity) && HasComponent<NeedToDestroy>(hitEntity) == false)
                {
                    _destroyEntities.Add(hitEntity);
                }
            }

        }).WithoutBurst().Run();

        foreach (Entity entity in _destroyEntities)
        {
            dstManager.AddComponentData(entity, new NeedToDestroy() { });
        }
    }
}