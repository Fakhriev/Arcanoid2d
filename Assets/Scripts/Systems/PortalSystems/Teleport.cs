using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class Teleport : SystemBase
{
    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;

        Entities
            .WithNone<PortalNotReady>()
            .ForEach((DynamicBuffer<TriggerBuffer> triggerBuffer, Entity entity, in Portal portal) => {

                for (int i = 0; i < triggerBuffer.Length; i++)
                {
                    if (dstManager.HasComponent<PortalNotReady>(entity))
                    {
                        Debug.Log($"123: {portal.side}");
                    }

                    if (dstManager.HasComponent<Player>(triggerBuffer[i].entity))
                    {
                        Debug.Log($"Portal collide with Player: {portal.side}");
                    }
                }

            //}).Schedule();
            }).WithoutBurst().Run();
    }   
}