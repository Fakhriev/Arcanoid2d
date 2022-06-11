using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class Teleport : SystemBase
{
    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;

        Entities.ForEach((DynamicBuffer<TriggerBuffer> triggerBuffer, Entity entity, in Portal portal) =>
        {
            for (int i = 0; i < triggerBuffer.Length; i++)
            {
                Entity triggerEntity = triggerBuffer[i].entity;

                if (dstManager.HasComponent<CanTeleport>(triggerEntity) && dstManager.HasComponent<Translation>(triggerEntity))
                {
                    CanTeleport canTeleport = dstManager.GetComponentData<CanTeleport>(triggerEntity);

                    if(canTeleport.immuneTime <= 0)
                    {
                        Translation translation = dstManager.GetComponentData<Translation>(triggerEntity);
                        float3 moveValue = portal.moveValue;

                        if(portal.moveValue.x != 0)
                        {
                            moveValue.x = (portal.moveValue.x > 0) ? portal.moveValue.x - canTeleport.colliderRadius * 1.5f :
                                                                        portal.moveValue.x + canTeleport.colliderRadius * 1.5f;
                        }
                        else if(portal.moveValue.y != 0)
                        {
                            moveValue.y = (portal.moveValue.y > 0) ? portal.moveValue.y - canTeleport.colliderRadius * 1.5f :
                                                                        portal.moveValue.y + canTeleport.colliderRadius * 1.5f;
                        }
                        else if (portal.moveValue.z != 0)
                        {
                            moveValue.z = (portal.moveValue.z > 0) ? portal.moveValue.z - canTeleport.colliderRadius * 1.5f :
                                                                        portal.moveValue.z + canTeleport.colliderRadius * 1.5f;
                        }

                        translation.Value += moveValue;
                        canTeleport.immuneTime = canTeleport.defaultImmuneTime;

                        dstManager.SetComponentData(triggerEntity, translation);
                        dstManager.SetComponentData(triggerEntity, canTeleport);
                    }
                }
            }

        }).WithoutBurst().Run();
    }   
}