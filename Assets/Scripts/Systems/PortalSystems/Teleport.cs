using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

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

                        translation.Value += portal.moveValue;
                        canTeleport.immuneTime = canTeleport.defaultImmuneTime;

                        dstManager.SetComponentData(triggerEntity, translation);
                        dstManager.SetComponentData(triggerEntity, canTeleport);
                    }
                }
            }

        }).WithoutBurst().Run();
    }   
}