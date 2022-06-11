using Unity.Entities;
using Unity.Jobs;
using UnityEngine.InputSystem;

public class PlayerLaserInput : SystemBase
{
    protected override void OnStartRunning()
    {
        Entities.ForEach((in Player player, in CanLaserShoot laserInputData, in PlayerInput playerInput) => {

            playerInput.actions.FindAction("Laser").performed += context => Laser();

        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {

    }

    private void Laser()
    {
        Entities.ForEach((ref CanLaserShoot canLaserShoot, in Player player) => {

            canLaserShoot.isLaserActive = true;

        }).WithoutBurst().Run();
    }
}