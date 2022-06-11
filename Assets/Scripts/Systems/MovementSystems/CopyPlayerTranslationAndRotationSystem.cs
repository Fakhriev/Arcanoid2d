using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class CopyPlayerTranslationAndRotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        EntityManager dstManager = World.EntityManager;
        Entity playerEntity = GetSingletonEntity<Player>();

        Translation playerTranslation = dstManager.GetComponentData<Translation>(playerEntity);
        Rotation playerRotation = dstManager.GetComponentData<Rotation>(playerEntity);

        Entities.ForEach((ref Translation translation, ref Rotation rotation, in CopyPlayerTranslationAndRotation d) => {

            translation = playerTranslation;
            rotation = playerRotation;
            
        }).Schedule();
    }
}