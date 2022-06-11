using Unity.Entities;
using Unity.Jobs;

public class PlayerFireInputData : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref CanBulletShoot canBulletShoot, in FireInputData fireInputData, in Player player) => {

            canBulletShoot.isShooting = fireInputData.isFiring;

        }).Schedule();
    }
}