using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

public class BulletShooting : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref CanBulletShoot canBulletShoot, in Translation translation, in Rotation rotation) =>
        {
            if (canBulletShoot.reloadingTime > 0)
            {
                canBulletShoot.reloadingTime -= deltaTime;
            }

            if (canBulletShoot.isShooting == true && canBulletShoot.reloadingTime <= 0)
            {
                Entity newBullet = EntityManager.Instantiate(canBulletShoot.bulletEntity);

                EntityManager.SetComponentData(newBullet, translation);
                EntityManager.SetComponentData(newBullet, rotation);

                canBulletShoot.reloadingTime = 0.25f;
            }

        }).WithStructuralChanges().Run();
    }
}