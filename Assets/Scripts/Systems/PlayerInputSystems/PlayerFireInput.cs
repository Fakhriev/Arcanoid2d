using Unity.Entities;
using Unity.Jobs;
using UnityEngine.InputSystem;

public class PlayerFireInput : SystemBase
{
    protected override void OnStartRunning()
    {
        Entities.ForEach((in Player player, in FireInputData fireInputData, in PlayerInput playerInput) => {

            playerInput.actions.FindAction("Fire").performed += context => Fire();

        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {

    }

    private void Fire()
    {
        Entities.ForEach((ref FireInputData fireInputData, in Player player) => {

            fireInputData.isFiring = !fireInputData.isFiring;

        }).WithoutBurst().Run();
    }
}