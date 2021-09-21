using Unity.Entities;
using Unity.Jobs;

public class PlayerInputToVelocityState : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Velocity velocity, in Player player, in InputData inputData) =>
        {
            if (inputData.moveInput.y > 0 && velocity.isDecreasing == true)
            {
                velocity.isDecreasing = false;
            }

            if (inputData.moveInput.y == 0)
            {
                if( (velocity.vector.x != 0 || velocity.vector.y != 0) && velocity.isDecreasing == false)
                {
                    velocity.isDecreasing = true;
                }

                if ( (velocity.vector.x == 0 && velocity.vector.y == 0) && velocity.isDecreasing)
                {
                    velocity.isDecreasing = false;
                }
            }

            if (inputData.moveInput.y < 0 && velocity.isDecreasing == false)
            {
                velocity.isDecreasing = true;
            }

        }).Schedule();
    }
}