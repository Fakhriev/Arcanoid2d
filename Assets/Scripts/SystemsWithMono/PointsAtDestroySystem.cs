using Unity.Entities;
using Unity.Jobs;

[UpdateBefore(typeof(SpawnAtDestroySystem))]
public class PointsAtDestroySystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((in NeedToDestroy needToDestroy, in PointsAtDestroy pointsAtDestroy) =>
        {
            GameManager.instance.AddPoints(pointsAtDestroy.value);

        }).WithoutBurst().Run();
    }
}