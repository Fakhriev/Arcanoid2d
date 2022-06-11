using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;

public class LaserCollidesEnemy : SystemBase
{
    private HashSet<Entity> destroyEntityes = new HashSet<Entity>();

    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;
        destroyEntityes.Clear();

        Entities
        .WithNone<NeedToDestroy>()
        .ForEach((DynamicBuffer<TriggerBuffer> triggerBuffer, Entity entity, in Laser laser) =>
        {
            for (int i = 0; i < triggerBuffer.Length; i++)
            {
                Entity hitEntity = triggerBuffer[i].entity;

                if (HasComponent<Enemy>(hitEntity) && HasComponent<NeedToDestroy>(hitEntity) == false)
                {
                    destroyEntityes.Add(hitEntity);
                }
            }

        }).WithoutBurst().Run();

        foreach (Entity entity in destroyEntityes)
        {
            dstManager.AddComponentData(entity, new NeedToDestroy() { });
        }
    }
}