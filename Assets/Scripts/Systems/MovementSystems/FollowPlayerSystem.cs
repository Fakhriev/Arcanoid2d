using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class FollowPlayerSystem: SystemBase
{
    protected override void OnUpdate()
    {
        if(TryGetSingletonEntity<Player>(out Entity playerEntity))
        {
            Translation playerTranslation = GetComponent<Translation>(playerEntity);

            Entities.ForEach((ref Movable movable, in Translation translation, in FollowPlayer followPlayer) => {

                movable.moveVector = math.normalize(playerTranslation.Value - translation.Value);

            }).Schedule();
        }
    }
}