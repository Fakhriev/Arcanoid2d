using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class LaserShooting : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref CanLaserShoot canLaserShoot, in Translation translation, in Rotation rotation) => {

            if (canLaserShoot.isLaserActive)
            {
                if (canLaserShoot.amount > 0)
                {
                    Entity newBullet = EntityManager.Instantiate(canLaserShoot.entity);

                    EntityManager.SetComponentData(newBullet, translation);
                    EntityManager.SetComponentData(newBullet, rotation);

                    canLaserShoot.amount--;
                }

                canLaserShoot.isLaserActive = false;
            }

        }).WithStructuralChanges().Run();
    }
}