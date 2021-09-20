using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class PlayerRotateInputSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        Entities.ForEach((in Player player, in InputData inputData, in PlayerInput playerInput) => {

            playerInput.actions.FindAction("Rotation").performed += context => Rotate(context.ReadValue<Vector2>());

        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {

    }

    private void Rotate(Vector2 direction)
    {
        Entities.ForEach((ref InputData inputData, in Player player) => {

            inputData.rotationInput = new float3(0, 0, -direction.x);

        }).WithoutBurst().Run();
    }
}