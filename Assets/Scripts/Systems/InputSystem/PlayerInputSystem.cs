using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class PlayerInputSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        Entities.ForEach((in Movable movable, in Player player, in PlayerInput playerInput) => {

            playerInput.actions.FindAction("Move").performed += context => Move(context.ReadValue<Vector2>());

        }).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {

    }

    private void Move(Vector2 direction)
    {
        Debug.Log($"{UnityEngine.Time.time}: {direction}");

        Entities.ForEach((ref Movable movable, in Player player, in PlayerInput playerInput) => {

            movable.velocityVector = math.float3(direction.x, direction.y, 0);

        }).WithoutBurst().Run();
    }
}
