using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;

public class BulletCollidesEnemy : SystemBase
{
    private HashSet<Entity> destroyEntities = new HashSet<Entity>();

    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;
        destroyEntities.Clear();

        Entities
        .WithNone<NeedToDestroy>()
        .ForEach((DynamicBuffer<CollisionBuffer> collisionBuffer, Entity entity, in Bullet bullet) =>
        {
           for (int i = 0; i < collisionBuffer.Length; i++)
           {
               Entity hitEntity = collisionBuffer[i].entity;

               if (HasComponent<Enemy>(hitEntity) && HasComponent<NeedToDestroy>(hitEntity) == false)
               {
                   destroyEntities.Add(hitEntity);
                   destroyEntities.Add(entity);
               }
           }

        }).WithoutBurst().Run();

        foreach(Entity entity in destroyEntities)
        {
            dstManager.AddComponentData(entity, new NeedToDestroy() { });
        }
    }
}