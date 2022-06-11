using Unity.Entities;
using Unity.Jobs;

public class LimitedLifetimeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        EntityManager dstManager = World.EntityManager;

        Entities.ForEach((Entity entity, ref LimitedLifetime limitedLifetime) => {

            if(limitedLifetime.value > 0)
            {
                limitedLifetime.value -= deltaTime;
            }
            else
            {
                dstManager.AddComponent<NeedToDestroy>(entity);
            }

        }).WithStructuralChanges().Run();
    }
}