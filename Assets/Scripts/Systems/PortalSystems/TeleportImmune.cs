using Unity.Entities;
using Unity.Jobs;

public class TeleportImmune : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref CanTeleport canTeleport) => {

            if(canTeleport.immuneTime > 0)
            {
                canTeleport.immuneTime -= deltaTime;
            }

        }).Schedule();
    }
}