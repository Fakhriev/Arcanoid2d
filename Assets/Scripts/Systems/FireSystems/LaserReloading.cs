using Unity.Entities;
using Unity.Jobs;

public class LaserReloading : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref CanLaserShoot canLaserShoot) =>
        {
            if (canLaserShoot.amount < canLaserShoot.maxAmount)
            {
                canLaserShoot.reload -= deltaTime;

                if (canLaserShoot.reload <= 0)
                {
                    canLaserShoot.amount++;
                    canLaserShoot.reload = canLaserShoot.reloadTime;
                }
            }


        }).Run();
    }
}