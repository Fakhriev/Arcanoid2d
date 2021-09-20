using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class PlayerMoveInputSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        Entities.ForEach((in Player player, in InputData inputData, in PlayerInput playerInput) => {

            playerInput.actions.FindAction("Move").performed += context => Move(context.ReadValue<Vector2>());

        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {

    }

    private void Move(Vector2 direction)
    {
        Entities.ForEach((ref InputData inputData, in Player player) => {

            inputData.moveInput = math.float3(direction.x, direction.y, 0);

        }).WithoutBurst().Run();
    }
}